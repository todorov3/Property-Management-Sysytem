using Dapper;
using PropertyManagementSystem.Data;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Repositories.Contracts;
using System.Data;

namespace PropertyManagementSystem.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly DapperContext _dapperContext;

        public FeedbackRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<Feedback> CreateFeedback(FeedbackCreateDto feedback)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("RequestId", feedback.RequestId, DbType.Int32);
            parameters.Add("Content", feedback.Content, DbType.String);
            parameters.Add("AuthorId", feedback.AuthorId, DbType.Int32);
            parameters.Add("CommentedUserId", feedback.CommentedUserId, DbType.Int32);
            parameters.Add("IsAuthorLandlord", feedback.IsAuthorLandlord, DbType.Boolean);
            parameters.Add("Rating", feedback.Rating, DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                var result = await connection.QuerySingleOrDefaultAsync<Feedback>(
                                                                                "spFeedbackCreate", 
                                                                                parameters, 
                                                                                commandType: 
                                                                                CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            using var connection = _dapperContext.CreateConnection();
            {
                return (await connection.QueryAsync<Feedback>(
                    "spFeedbackGetAll",
                    commandType: 
                    CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<List<Feedback>> GetAllFeedbacksAsLandlord(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("UserId", userId, DbType.Int32);

            using var connections = _dapperContext.CreateConnection();
            {
                return (await connections.QueryAsync<Feedback>(
                                                            "spFeedbackGetAllAsLandlord", 
                                                            parameters, 
                                                            commandType: 
                                                            CommandType.StoredProcedure))
                                                            .ToList();
            }
        }

        public async Task<List<Feedback>> GetAllFeedbacksAsTenand(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("UserId", userId , DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                return (await connection.QueryAsync<Feedback>(
                                                            "spFeedbackGetAllAsTenand", 
                                                            parameters, 
                                                            commandType: 
                                                            CommandType.StoredProcedure))
                                                            .ToList();
            }
        }

        public async Task<double> GetAverageRatingAsLandlord(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", userId, DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                return await connection.QuerySingleOrDefaultAsync<double>(
                    "spFeedbackGetAverageRatingAsLandlord", 
                    parameters, 
                    commandType: 
                    CommandType.StoredProcedure);
            }
        }

        public async Task<double> GetAverageRatingAsTenand(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", userId, DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                return await connection.QuerySingleOrDefaultAsync<double>(
                    "spFeedbackGetAverageRatingAsTenand", 
                    parameters, 
                    commandType: 
                    CommandType.StoredProcedure);
            }
        }

        public async Task<Feedback> GetFeedbackById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                return await connection.QuerySingleOrDefaultAsync<Feedback>(
                                                                        "spFeedbackGetById", 
                                                                        parameters, 
                                                                        commandType: 
                                                                        CommandType.StoredProcedure);
            }
        }

        public async Task<List<Feedback>> GetAllFeedbacksByUserId(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", userId, DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                return (await connection.QueryAsync<Feedback>(
                                                            "spFeedbackGetAllByUserId", 
                                                            parameters, 
                                                            commandType: 
                                                            CommandType.StoredProcedure))
                                                            .ToList();
            }
        }

        public async Task<Feedback> UpdateFeedback(int id, FeedbackUpdateDto feedback)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Content", feedback.Content, DbType.String);
            parameters.Add("Rating", feedback.Rating, DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                await connection.ExecuteAsync(
                                            "spFeedbackUpdate", 
                                            parameters, 
                                            commandType: 
                                            CommandType.StoredProcedure);
                return GetFeedbackById(id).Result;
            }
        }
    }
}
