using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NewsLatterManager : INewsLatterService
    {
        private INewsLatterDal _newsLatterDal;

        public NewsLatterManager(INewsLatterDal newsLatterDal)
        {
            _newsLatterDal = newsLatterDal;
        }

        public void AddNewsLatter(NewsLatter newsLatter)
        {
          _newsLatterDal.Insert(newsLatter);
        }
    }
}
