using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper.Contrib.Extensions;
using OpenRetail.Model;
using OpenRetail.Repository.Api;
 
namespace OpenRetail.Repository.Service
{        
    public class AlasanPenyesuaianStokRepository : IAlasanPenyesuaianStokRepository
    {
        private IDapperContext _context;

        public AlasanPenyesuaianStokRepository(IDapperContext context)
        {
            this._context = context;
        }

        public AlasanPenyesuaianStok GetByID(string id)
        {
            AlasanPenyesuaianStok obj = null;

            try
            {
                obj = _context.db.Get<AlasanPenyesuaianStok>(id);
            }
            catch
            {
            }

            return obj;
        }

        public IList<AlasanPenyesuaianStok> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IList<AlasanPenyesuaianStok> GetAll()
        {
            IList<AlasanPenyesuaianStok> oList = new List<AlasanPenyesuaianStok>();

            try
            {
                oList = _context.db.GetAll<AlasanPenyesuaianStok>()
                                .OrderBy(f => f.alasan)
                                .ToList();
            }
            catch
            {
            }

            return oList;
        }

        public int Save(AlasanPenyesuaianStok obj)
        {
            var result = 0;

            try
            {
                obj.alasan_penyesuaian_stok_id = _context.GetGUID();

                _context.db.Insert<AlasanPenyesuaianStok>(obj);
                result = 1;
            }
            catch
            {
            }

            return result;
        }

        public int Update(AlasanPenyesuaianStok obj)
        {
            var result = 0;

            try
            {
                result = _context.db.Update<AlasanPenyesuaianStok>(obj) ? 1 : 0;
            }
            catch
            {
            }

            return result;
        }

        public int Delete(AlasanPenyesuaianStok obj)
        {
            var result = 0;

            try
            {
                result = _context.db.Delete<AlasanPenyesuaianStok>(obj) ? 1 : 0;
            }
            catch
            {
            }

            return result;
        }
    }
}     