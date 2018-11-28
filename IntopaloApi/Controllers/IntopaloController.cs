using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using IntopaloApi.System_for_data_governance;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace IntopaloApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntopaloController : ControllerBase
    {
        private readonly DataGovernanceDBContext _context;

        public IntopaloController(DataGovernanceDBContext context)
        {
            _context = context;

            if (_context.Collections.Count() == 0)
            {
                // Create a new IntopaloItem if collection is empty,
                // which means you can't delete all IntopaloItems.
                _context.Collections.Add(new Collection { Name = "IntopaloCollection1" });
                _context.SaveChanges();
            }
            if (_context.Schemas.Count() == 0)
            {
                _context.Schemas.Add(
                    new Schema {
                        Name = "private",
                        Tables = new List<Table> {
                            new Table { 
                                Name = "User",
                                Fields = new List<Field> {
                                    new Field {Name = "UserId", Type = "int" },
                                    new Field {Name = "UserName", Type = "nvarchar(max)" }
                                }

                            },

                            new Table {
                                Name = "Car",
                                Fields = new List<Field> {
                                    new Field {Name = "CarId", Type = "int" },
                                    new Field {Name = "OwnerId", Type = "int" },
                                    new Field {Name = "CarBrand", Type = "nvarchar(max)" }
                                }
                            }
                        }
                    }
                );
                _context.SaveChanges();
                _context.KeyRelationships.Add(new KeyRelationship{
                    FromId = _context.Fields.Single(f => f.Name == "UserId").Id,
                    ToId = _context.Fields.Single(f => f.Name == "OwnerId").Id,
                    Type = "exact"
                });
                _context.SaveChanges();
            }
   
            
        }
        [HttpGet]
        public ActionResult<string> GetAll() {
            List<Table> tables = _context.Tables
                .Include(t => t.Fields)
                .ThenInclude(f => f.PrimaryKeyTo)
                .ToList();
            //tables[0].Fields[0].KeyRelationshipFrom[0].BaseTo = null;
            //tables[1].Fields[1].KeyRelationshipTo[0].BaseFrom = null;
            return JsonConvert.SerializeObject(
                tables,
                new JsonSerializerSettings() {
                    /* Allow loops since metadata is connected in a hierarchy. */
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    /* Identing for debug purposes only */
                    Formatting = Formatting.Indented
                }
            );
        }
    }
}
