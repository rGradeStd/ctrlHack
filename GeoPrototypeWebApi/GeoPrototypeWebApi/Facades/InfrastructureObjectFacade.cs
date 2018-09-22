﻿using System;
using System.Collections.Generic;
using System.Linq;
using GeoPrototypeWebApi.Models;

namespace GeoPrototypeWebApi.Facades
{
    public class InfrastructureObjectFacade : DbBaseFacade
    {
        public InfrastructureObjectFacade()
        {
        }


        public IEnumerable<InfrastructureObjectMapInfo> GetObjectsByYear(int year) 
        {
            var retVal = new List<InfrastructureObjectMapInfo>();

            using (var connection = GetDbConnection()) 
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = SqlStrings.GetObjectsByYear;

                var dateFrom = new DateTime(year, 1, 1);
                var dateTo = new DateTime(year, 12, 31);

                cmd.AddParameter("@dateFrom", dateFrom);
                cmd.AddParameter("@dateTo", dateTo);

                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    var databaseObject = new InfrastructureObjectDatabaseInfo();
                    databaseObject.Id = (long)dataReader["id"];
                    databaseObject.ContractNumber = (string)(dataReader["contract_number"] == DBNull.Value ? "" : dataReader["contract_number"]);
                    databaseObject.Address = (string)(dataReader["address"] == DBNull.Value ? "" : dataReader["address"]);
                    databaseObject.TempAddress = (string)(dataReader["temp_address"] == DBNull.Value ? "" : dataReader["temp_address"]);
                    databaseObject.Latitude = (decimal)(dataReader["latitude"] == DBNull.Value ? new decimal() : dataReader["latitude"]);
                    databaseObject.Longitude = (decimal)(dataReader["longitude"] == DBNull.Value ? new decimal() : dataReader["latitude"]);
                    databaseObject.TempObjectType = (string)(dataReader["temp_object_type"] == DBNull.Value ? "" : dataReader["temp_object_type"]);
                    databaseObject.ObjectType = (string)(dataReader["object_type"] == DBNull.Value ? "" : dataReader["object_type"]);
                    databaseObject.WorkType = (string)(dataReader["work_type"] == DBNull.Value ? "" : dataReader["work_type"]);
                    databaseObject.StartDate = (DateTime)(dataReader["start_date"] == DBNull.Value ? null : dataReader["start_date"]);
                    databaseObject.FinishDate = (DateTime)(dataReader["finish_date"] == DBNull.Value ? null : dataReader["finish_date"]);
                    databaseObject.CustomerName = (string)(dataReader["customer_name"] == DBNull.Value ? "" : dataReader["customer_name"]);
                    databaseObject.CustomerPhone = (string)(dataReader["customer_phone"] == DBNull.Value ? "" : dataReader["customer_phone"]);
                    databaseObject.ContractorName = (string)(dataReader["contractor_name"] == DBNull.Value ? "" : dataReader["contractor_name"]);
                    databaseObject.ContractorPhone = (string)(dataReader["contractor_phone"] == DBNull.Value ? "" : dataReader["contractor_phone"]);
                    databaseObject.Url = (string)(dataReader["contract_url"] == DBNull.Value ? "" : dataReader["contract_url"]);
                    databaseObject.Description = (string)(dataReader["description"] == DBNull.Value ? "" : dataReader["description"]);

                    var mapObject = new InfrastructureObjectMapInfo();
                    mapObject.ConvertToMapObject(databaseObject);
                    retVal.Add(mapObject);
                }
            }

            return retVal;
        }

        public IEnumerable<InfrastructureObjectMapInfo> GetObjectById(int id) 
        {
            var retVal = new List<InfrastructureObjectMapInfo>();

            using (var connection = GetDbConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = SqlStrings.GetObjectById;

                cmd.AddParameter("@id", id);

                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    var databaseObject = new InfrastructureObjectDatabaseInfo();
                    databaseObject.Id = (long)dataReader["id"];
                    databaseObject.ContractNumber = (string)(dataReader["contract_number"] == DBNull.Value ? "" : dataReader["contract_number"]);
                    databaseObject.Address = (string)(dataReader["address"] == DBNull.Value ? "" : dataReader["address"]);
                    databaseObject.TempAddress = (string)(dataReader["temp_address"] == DBNull.Value ? "" : dataReader["temp_address"]);
                    databaseObject.Latitude = (decimal)(dataReader["latitude"] == DBNull.Value ? new decimal() : dataReader["latitude"]);
                    databaseObject.Longitude = (decimal)(dataReader["longitude"] == DBNull.Value ? new decimal() : dataReader["latitude"]);
                    databaseObject.TempObjectType = (string)(dataReader["temp_object_type"] == DBNull.Value ? "" : dataReader["temp_object_type"]);
                    databaseObject.ObjectType = (string)(dataReader["object_type"] == DBNull.Value ? "" : dataReader["object_type"]);
                    databaseObject.WorkType = (string)(dataReader["work_type"] == DBNull.Value ? "" : dataReader["work_type"]);
                    databaseObject.StartDate = (DateTime)(dataReader["start_date"] == DBNull.Value ? null : dataReader["start_date"]);
                    databaseObject.FinishDate = (DateTime)(dataReader["finish_date"] == DBNull.Value ? null : dataReader["finish_date"]);
                    databaseObject.CustomerName = (string)(dataReader["customer_name"] == DBNull.Value ? "" : dataReader["customer_name"]);
                    databaseObject.CustomerPhone = (string)(dataReader["customer_phone"] == DBNull.Value ? "" : dataReader["customer_phone"]);
                    databaseObject.ContractorName = (string)(dataReader["contractor_name"] == DBNull.Value ? "" : dataReader["contractor_name"]);
                    databaseObject.ContractorPhone = (string)(dataReader["contractor_phone"] == DBNull.Value ? "" : dataReader["contractor_phone"]);
                    databaseObject.Url = (string)(dataReader["contract_url"] == DBNull.Value ? "" : dataReader["contract_url"]);
                    databaseObject.Description = (string)(dataReader["description"] == DBNull.Value ? "" : dataReader["description"]);

                    var mapObject = new InfrastructureObjectMapInfo();
                    mapObject.ConvertToMapObject(databaseObject);
                    retVal.Add(mapObject);
                }
            }

            return retVal;
        }
    }
}
