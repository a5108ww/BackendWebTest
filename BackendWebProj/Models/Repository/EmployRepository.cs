using BackendWebProj.Context;
using BackendWebProj.Helper;
using System.Text;

namespace BackendWebProj.Models.Repository
{
    public class EmployRepository : AbstractEntityRepository<Employ>
    {
        public EmployRepository(BackendWebContext _db) : base(_db)
        {
        }

        public override IQueryable<Employ> GetEntitiesQ()
        {
            return db.Employ.Where(m => !m.removed);
        }

        public override Employ GetById(Int64 id)
        {
            return db.Employ.Where(m => !m.removed && m.id == id).FirstOrDefault();
        }

        public async Task<string> SaveEntity(Employ employ)
        {
            Employ editEmploy = employ;

            if (employ != null && employ.id > 0)
            {
                editEmploy = GetById(employ.id);
            }

            editEmploy.name = employ.name;
            editEmploy.dateOfBirth = employ.dateOfBirth;
            editEmploy.salary = employ.salary;
            editEmploy.address = employ.address;

            string result = CheckModelIsOk(editEmploy);

            if (!string.IsNullOrWhiteSpace(result))
            {
                await SaveAsync(editEmploy);
            }

            return result;
        }

        public string CheckModelIsOk(Employ employ)
        {
            string result = "";
            StringBuilder sb = null;

            if (employ == null)
            {
                sb = StringHelper.AppentStringToStringBuilder(sb, "資料異常");
            }
            else
            {
                if (employ.dateOfBirth == null || Convert.ToDateTime(employ.dateOfBirth).CompareTo(new DateTime(1950, 1, 1)) <= 0)
                {
                    sb = StringHelper.AppentStringToStringBuilder(sb, "生日資料異常");
                }
            }

            return sb != null ? sb.ToString().Trim() : "";
        }
    }
}
