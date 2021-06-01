using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemirorenTech.Business.Commons.Models.CommonModels
{
    public class Paging
    {
        public Paging()
        {

        }

        private int HalfCount { get; set; }//sayfalamanın yarısı
        private int TotalCount { get; set; }//toplam sayfalama sayısı
        private int PageSize { get; set; }//sayfalama sayısı
        private List<int> PagingNumbers { get; set; }//sayfalama sayılarının numara listesi
        public int TotalRecordCount { get; set; }//Toplam kayıt sayısı
        public int Take { get; set; }//kaç kayıt alınacağı bilgisi
        public int Index { get; set; }//kaçıncı sayfada olduğu
        public string PageList { get; set; }//kaçıncı sayfada olduğu
        private int listLimit = 5;//page numaralamada indexden once ve sonrasindaki rakam araligi
        public int PageTotalCount = 0;//gösterilen son page den bir sonra ki sayfa

        private int FirstNumber
        {
            get
            {
                if (Index - HalfCount > 1)
                {
                    return Index - HalfCount;
                }
                else
                {
                    return 0;
                }
            }

        }

        private int NextNumber
        {
            get
            {
                if (Index - HalfCount > 1)
                {
                    if (Index + HalfCount < TotalCount)
                    {
                        return Index + HalfCount;
                    }
                    else
                    {
                        return TotalCount;
                    }
                }
                else
                {
                    if (FindLastDigit(Index, PageSize) < TotalCount)
                    {
                        return FindLastDigit(Index, PageSize);
                    }
                    else
                    {
                        return TotalCount;
                    }
                }
            }
        }

        private int NextDifference
        {
            get { return TotalCount - NextNumber; }
        }

        private int FindFirstDigit(int number, int div)
        {
            return Math.Abs(number - (number % div) - div);
        }

        private int FindLastDigit(int number, int div)
        {
            return number - (number % div) + div;
        }

        private int Difference(int totalCount, List<int> lastCount)
        {
            return totalCount - lastCount[0];
        }

        private void CalculateNextPages(int start, int count, int div, int totalCount, List<int> lastCount)
        {
            try
            {
                for (int i = start; i < count; i++)
                {
                    int ncount = FindLastDigit(lastCount[i], div);
                    if (ncount < totalCount && !lastCount.Contains(ncount))
                    {
                        lastCount.Add(ncount);
                    }
                    else if (!lastCount.Contains(totalCount))
                    {
                        lastCount.Add(totalCount);
                    }
                }
            }
            catch (Exception e)
            {

            }

        }

        private void CalculateFirstPages(int start, int count, int div, List<int> lastCount)
        {
            for (int i = start; i < count; i++)
            {
                int ncount = FindFirstDigit(lastCount[i], div);
                if (ncount > 0 && !lastCount.Contains(ncount))
                {
                    lastCount.Add(ncount);
                }
                else if (!lastCount.Contains(0))
                {
                    lastCount.Add(0);
                }
            }
        }

        private List<int> FindLastGroupNumbers()
        {
            List<int> lastCount = PagingNumbers;
            if (NextDifference < 10)
            {
                lastCount.Add(TotalCount);
            }
            else if (NextDifference < 50)
            {
                AddLastDigit(10);
                CalculateNextPages(0, (Difference(TotalCount, lastCount) / 10), 10, TotalCount, lastCount);
            }
            else if (NextDifference <= 100)
            {
                AddLastDigit(10);
                CalculateNextPages(0, (Difference(TotalCount, lastCount) / 10), 10, TotalCount, lastCount);
            }
            else if (NextDifference < 500)
            {
                AddLastDigit(10);
                AddLastDigit(50);
                int start = lastCount.Count - 1;
                CalculateNextPages(start, (Difference(TotalCount, lastCount) / 50) + start, 50, TotalCount, lastCount);
            }
            else if (NextDifference < 750)
            {
                AddLastDigit(10);
                AddLastDigit(50);
                AddLastDigit(100);
                int start = lastCount.Count - 1;
                CalculateNextPages(start, (Difference(TotalCount, lastCount) / 100) + start, 100, TotalCount, lastCount);
            }
            else if (NextDifference < 1000)
            {
                AddLastDigit(10);
                AddLastDigit(50);
                AddLastDigit(100);
                AddLastDigit(250);
                int start = lastCount.Count - 1;
                CalculateNextPages(start, (Difference(TotalCount, lastCount) / 250) + start, 250, TotalCount, lastCount);
            }
            else if (NextDifference < 2500)
            {
                AddLastDigit(10);
                AddLastDigit(50);
                AddLastDigit(100);
                AddLastDigit(250);
                AddLastDigit(500);
                int start = lastCount.Count - 1;
                CalculateNextPages(start, (Difference(TotalCount, lastCount) / 500) + start, 500, TotalCount, lastCount);
            }
            else if (NextDifference < 5000)
            {
                AddLastDigit(10);
                AddLastDigit(100);
                AddLastDigit(500);
                AddLastDigit(750);
                int start = lastCount.Count - 1;
                CalculateNextPages(start, (Difference(TotalCount, lastCount) / 750) + start, 750, TotalCount, lastCount);
            }
            else if (NextDifference < 7500)
            {
                AddLastDigit(10);
                AddLastDigit(100);
                AddLastDigit(500);
                AddLastDigit(750);
                AddLastDigit(1000);
                int start = lastCount.Count - 1;
                CalculateNextPages(start, (Difference(TotalCount, lastCount) / 1000) + start, 1000, TotalCount, lastCount);
            }
            return lastCount;
        }

        private List<int> FindFirstPartNumbers()
        {
            List<int> firstCount = PagingNumbers;
            if (FirstNumber < 10)
            {
                firstCount.Add(0);
            }
            if (FirstNumber < 50)
            {
                AddFirstDigit(10);
                CalculateFirstPages(0, (FirstNumber / 10), 10, firstCount);
            }
            else if (FirstNumber <= 100)
            {
                AddFirstDigit(10);
                CalculateFirstPages(0, (FirstNumber / 10), 10, firstCount);
            }
            else if (FirstNumber < 500)
            {
                AddFirstDigit(10);
                AddFirstDigit(50);
                int start = firstCount.Count - 1;
                CalculateFirstPages(start, (FirstNumber / 50) + start, 50, firstCount);
            }
            else if (FirstNumber < 750)
            {
                AddFirstDigit(10);
                AddFirstDigit(50);
                AddFirstDigit(100);
                int start = firstCount.Count - 1;
                CalculateFirstPages(start, (FirstNumber / 100) + start, 100, firstCount);
            }
            else if (FirstNumber < 1000)
            {
                AddFirstDigit(10);
                AddFirstDigit(50);
                AddFirstDigit(100);
                AddFirstDigit(250);
                int start = firstCount.Count - 1;
                CalculateFirstPages(start, (FirstNumber / 250) + start, 250, firstCount);
            }
            else if (FirstNumber < 2500)
            {
                AddFirstDigit(10);
                AddFirstDigit(50);
                AddFirstDigit(100);
                AddFirstDigit(250);
                AddFirstDigit(500);
                int start = firstCount.Count - 1;
                CalculateFirstPages(start, (FirstNumber / 500) + start, 500, firstCount);
            }
            else if (FirstNumber < 5000)
            {
                AddFirstDigit(10);
                AddFirstDigit(100);
                AddFirstDigit(500);
                AddFirstDigit(750);
                int start = firstCount.Count - 1;
                CalculateFirstPages(start, (FirstNumber / 750) + start, 750, firstCount);
            }
            else if (FirstNumber < 7500)
            {
                AddFirstDigit(10);
                AddFirstDigit(100);
                AddFirstDigit(500);
                AddFirstDigit(750);
                AddFirstDigit(1000);
                int start = firstCount.Count - 1;
                CalculateFirstPages(start, (FirstNumber / 1000) + start, 1000, firstCount);
            }

            return firstCount;
        }

        private void AddFirstDigit(int level)
        {
            int number = FindFirstDigit(NextNumber, level);
            if (!PagingNumbers.Contains(number)) PagingNumbers.Add(number);
        }

        private void AddLastDigit(int level)
        {
            int number = FindLastDigit(NextNumber, level);
            if (!PagingNumbers.Contains(number)) PagingNumbers.Add(number);
        }

        private string GenerateCenterNumbers(int start, int end, string delimiter = "-", bool mark = true, int totalCount = 0, int takeCount = 0)
        {
            int mod = 0;
            if (takeCount > 0)
            {
                mod = totalCount % takeCount; //Toplam item sayısının paging take değerine göre küsüratlı olup olmama durumları kontrol edildi. YSK
            }
            string numbers = delimiter;
            end = mod == 0 ? end : end + 1;
            for (int i = start; i < end; i++)
            {
                if (!PagingNumbers.Contains(i))
                {
                    PagingNumbers.Add(i);
                }
            }

            return numbers + delimiter;
        }

        private int Skip
        {
            get { return Convert.ToInt32(Index) * Convert.ToInt32(Take); }
        }

        public string PagingList<T>(RequestToken<T> token, int totalRecord)
        {
            //return PagingList(token.Paging.Index, token.Paging.Take, totalRecord);
            Pager pager = new Pager(totalRecord, token.Paging.Index, token.Paging.Take);
            var PagingNumbers = new List<int>();


            int totalPage = pager.TotalPages;
            int startpage = pager.StartPage;
            int endPage = pager.EndPage;
            int selectedPage = token.Paging.Index;
            TotalRecordCount = totalRecord;
            //int counterPageCache = 0;

            PagingNumbers.Add(0);
            for (int i = startpage - 1; i < endPage; i++)
            {
                if (!PagingNumbers.Contains(i))
                {
                    PagingNumbers.Add(i);

                }
            }
            if (totalPage > 10 && !PagingNumbers.Contains((totalPage - 1)))
            {
                PagingNumbers.Add((totalPage - 1));
                PageTotalCount = totalPage - 1;
            }
            PageList += String.Join("-", PagingNumbers);
            return PageList;
        }

        public string PagingList(int index, int take, int totalRecordCount, string delimiter = "-", bool mark = true)
        {
            Take = take;
            Index = index;
            PageSize = take;


            TotalRecordCount = totalRecordCount;
            PagingNumbers = new List<int>();

            //Toplam sayfa sayısı = toplam kayıt / sayfalama sayısı
            PageSize = PageSize == 0 ? 1 : PageSize;
            TotalCount = TotalRecordCount / PageSize;
            if (FirstNumber > listLimit)
            {
                //generate first part of numbers
                FindFirstPartNumbers();
            }

            int dif = listLimit - index > 0 ? listLimit - index : 0;
            int start = index - listLimit > 0 ? index - listLimit : 0;
            int end = index + listLimit + dif <= TotalCount ? index + listLimit + dif : TotalCount;

            PagingNumbers = PagingNumbers.Distinct().ToList();
            //Ortadaki liste oluşturuluyor
            GenerateCenterNumbers(start, end, delimiter, mark, totalRecordCount, take);

            if (TotalCount > listLimit)
            {
                //generate last part of numbers
                FindLastGroupNumbers();
            }
            PagingNumbers = PagingNumbers.Distinct().ToList();
            PagingNumbers.Sort();
            //write to string with delimiter
            PageList += String.Join(delimiter, PagingNumbers);
            if (mark)
            {
                PageList = PageList.Replace("-" + Index.ToString() + "-", "-[" + Index.ToString() + "]-");
            }

            return PageList;
        }
    }
}
