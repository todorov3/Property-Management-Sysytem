using Dapper;
using System.Data;
using PropertyManagementSystem.Data;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Repositories.Contracts;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DapperContext _dapperContext;

        public PropertyRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<Property> GetPropertyById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using var connection = _dapperContext.CreateConnection();
            {
                return await connection.QuerySingleOrDefaultAsync<Property>(
                                                                        "spPropertyGetById", 
                                                                        connection, 
                                                                        commandType: 
                                                                        CommandType.StoredProcedure);
            }
        }

        public async Task<List<Property>> GetPropertyByLandlordId(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using var connection = _dapperContext.CreateConnection();
            {
                return (await connection.QueryAsync<Property>(
                                                        "spPropertyGetByLandlordId", 
                                                        connection, 
                                                        commandType: 
                                                        CommandType.StoredProcedure))
                                                        .ToList();
            }
        }

        public async Task<List<Property>> GetAllProperties()
        {
            using var connection = _dapperContext.CreateConnection();
            {
                return (await connection.QueryAsync<Property>(
                                                        "spPropertiesGetAll", 
                                                        connection, 
                                                        commandType: 
                                                        CommandType.StoredProcedure))
                                                        .ToList();
            }
        }

        public async Task<Property> CreateProperty(PropertyCreateDto propertyDto)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("LandlordId", propertyDto.LandlordId, DbType.Int32);
            parameters.Add("TownId", propertyDto.TownName, DbType.Int32);
            parameters.Add("PropertyType", propertyDto.PropertyType, DbType.Int32);
            parameters.Add("Area", propertyDto.Area, DbType.Int32);
            parameters.Add("NumOfRooms", propertyDto.NumOfRooms, DbType.Int32);
            parameters.Add("NumOfFloors", propertyDto.NumOfFloors, DbType.Int32);
            parameters.Add("NumOfBedrooms", propertyDto.NumOfBedrooms, DbType.Int32);
            parameters.Add("NumOfBathrooms", propertyDto.NumOfBathrooms, DbType.Int32);
            parameters.Add("PetsAllowed", propertyDto.PetsAllowed, DbType.Boolean);
            parameters.Add("YardArea", propertyDto.YardArea, DbType.Int32);
            parameters.Add("Price", propertyDto.Price, DbType.Decimal);

            using var connection = _dapperContext.CreateConnection();
            {
                var result = await connection.QuerySingleOrDefaultAsync<Property>(
                                                                            "spPropertyCreate", 
                                                                            parameters, 
                                                                            commandType: 
                                                                            CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<Property> UpdateProperty(int id, PropertyUpdateDto property)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("PetsAllowed", property.PetsAllowed, DbType.Boolean);
            parameters.Add("Price", property.Price, DbType.Decimal);
            //parameters.Add("FreeDates", property.FreeDates, DbType.Date);

            using var connection = _dapperContext.CreateConnection();
            {
                await connection.ExecuteAsync(
                                            "spPropertyUpdate", 
                                            parameters, 
                                            commandType: 
                                            CommandType.StoredProcedure);
                return GetPropertyById(id).Result;
            }
        }

        public async Task DeleteProperty(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using var connection = _dapperContext.CreateConnection();
            {
                await connection.ExecuteAsync(
                                            "spPropertyDelete", 
                                            parameters, 
                                            commandType: 
                                            CommandType.StoredProcedure);
            }
        }
        public async Task<Property> ArchiveProperty(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using var connection = _dapperContext.CreateConnection();
            {
                return await connection.QuerySingleOrDefaultAsync<Property>(
                                                                        "spPropertyArchive", 
                                                                        parameters, 
                                                                        commandType: 
                                                                        CommandType.StoredProcedure);
            }
        }
    }
}
