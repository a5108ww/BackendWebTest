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

        public async Task<string> SaveEntity(List<Employ> employs)
        {
            string result = "";

            try
            {
                if (employs != null && employs.Count > 0)
                {
                    List<Employ> editEmploys = new List<Employ>();
                    foreach (Employ employ in employs)
                    {
                        result = CheckModelIsOk(employ);
                        if (string.IsNullOrWhiteSpace(result))
                        {
                            DateTime dateOfBirth = new DateTime();
                            if(DateTime.TryParse(employ.dateOfBirthString, out dateOfBirth))
                            {
                                employ.dateOfBirth = dateOfBirth;
                            }

                            if (employ.id > 0)
                            {
                                Employ tempEmploy = GetById(employ.id);

                                tempEmploy.name = employ.name;
                                tempEmploy.dateOfBirth = employ.dateOfBirth;
                                tempEmploy.salary = employ.salary;
                                tempEmploy.address = employ.address;

                                editEmploys.Add(tempEmploy);
                            }
                            else
                            {
                                editEmploys.Add(employ);
                            }
                        }
                    }

                    if(editEmploys != null && editEmploys.Count > 0)
                    {
                       await SaveAsync(editEmploys);
                    }
                }
            }
            catch(Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        public async Task<string> SaveEntity(Employ employ)
        {
            return await SaveEntity(new List<Employ>() { employ });
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
