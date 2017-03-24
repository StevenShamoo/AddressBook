using AddressBook.Domain;
using AddressBook.Models.Request;
using Sabio.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AddressBook.Services
{
    public class AddressService : BaseService
    {
        public static void Insert(AddressAddRequest model)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Address_Insert",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@UserId", model.UserId);
                    paramCollection.AddWithValue("@Name", model.Name);
                    paramCollection.AddWithValue("@Street", model.Street);
                    paramCollection.AddWithValue("@Street2", model.Street2);
                    paramCollection.AddWithValue("@City", model.City);
                    paramCollection.AddWithValue("@State", model.State);
                    paramCollection.AddWithValue("@PostalCode", model.PostalCode);

                });
        }

        public static void Update(AddressUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Address_UpdateOne",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@AddressId", model.Id);
                    paramCollection.AddWithValue("@UserId", model.UserId);
                    paramCollection.AddWithValue("@Name", model.Name);
                    paramCollection.AddWithValue("@Street", model.Street);
                    paramCollection.AddWithValue("@Street2", model.Street2);
                    paramCollection.AddWithValue("@City", model.City);
                    paramCollection.AddWithValue("@State", model.State);
                    paramCollection.AddWithValue("@PostalCode", model.PostalCode);
                });
        }

        public static Address GetById(Guid AddressId)
        {
            Address a = new Address();

            DataProvider.ExecuteCmd(GetConnection, "dbo.Address_SelectOne"
             , inputParamMapper: delegate (SqlParameterCollection paramCollection)
             {
                 paramCollection.AddWithValue("@AddressId", AddressId);
             }

             , map: delegate (IDataReader reader, short set)
             {
                 int startingIndex = 0;

                 a.Id = reader.GetSafeGuid(startingIndex++);
                 a.UserId = reader.GetSafeInt32(startingIndex++);
                 a.Name = reader.GetSafeString(startingIndex++);
                 a.Street = reader.GetSafeString(startingIndex++);
                 a.Street2 = reader.GetSafeString(startingIndex++);
                 a.City = reader.GetSafeString(startingIndex++);
                 a.State = reader.GetSafeString(startingIndex++);
                 a.PostalCode = reader.GetSafeString(startingIndex++);
                 a.CreationDateTime = reader.GetSafeDateTime(startingIndex++);


             });

            return a;
        }

        public static List<Address> GetAll(int UserId)
        {
            List<Address> list = new List<Address>();

            DataProvider.ExecuteCmd(GetConnection, "dbo.Address_SelectAll"
              , inputParamMapper: delegate (SqlParameterCollection paramCollection)
              {
                  paramCollection.AddWithValue("@UserId", UserId);
              }
              , map: delegate (IDataReader reader, short set)
              {
                  Address a = new Address();
                  int startingIndex = 0; //startingOrdinal

                  a.Id = reader.GetSafeGuid(startingIndex++);
                  a.UserId = reader.GetSafeInt32(startingIndex++);
                  a.Name = reader.GetSafeString(startingIndex++);
                  a.Street = reader.GetSafeString(startingIndex++);
                  a.Street2 = reader.GetSafeString(startingIndex++);
                  a.City = reader.GetSafeString(startingIndex++);
                  a.State = reader.GetSafeString(startingIndex++);
                  a.PostalCode = reader.GetSafeString(startingIndex++);
                  a.CreationDateTime = reader.GetSafeDateTime(startingIndex++);

                  if (list == null)
                  {
                      list = new List<Address>();
                  }
                  list.Add(a);
              });

            return list;
        }

        public static void DeleteById(Guid AddressId)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Address_DeleteOne"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@AddressId", AddressId);
                });
        }

    }

}