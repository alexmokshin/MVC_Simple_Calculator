﻿using System;
using System.Collections.Generic;
using System.Linq;
using MVC_Simple_Calculator.Models.DatabaseLayer.DatabaseConnection;
using System.Data.Sql;
using MVC_Simple_Calculator.Models.Service;
using System.Data.SqlClient;
using System.Data;

namespace MVC_Simple_Calculator.Models.DatabaseLayer.Database_Access_Object
{
    public class DatabaseService
    {   
        private SqlConnection CONNECTION { get; set; }

        public DatabaseService()
        {
            this.CONNECTION = DatabaseConnection.DatabaseConnection.ConnectionDatabase();
        }

        public List<UserEvents> GetEventsFromDatabase(string user_ip)
        {
            List<UserEvents> list_events = new List<UserEvents>();
            using (SqlConnection conn = CONNECTION)
            {
                try
                {
                    conn.Open();
                    SqlCommand get_events_command = new SqlCommand("dbo.SEL_USERS_EVENTS", conn);
                    get_events_command.CommandType = CommandType.StoredProcedure;
                    SqlParameter user_name = new SqlParameter
                    {
                        ParameterName = "@user_name",
                        Value = user_ip,
                        SqlDbType = SqlDbType.VarChar
                    };
                    get_events_command.Parameters.Add(user_name);
                    var reader = get_events_command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            
                            var t = new UserEvents(Convert.ToChar(reader["operation_char"]));
                            t.ID = Convert.ToInt32(reader["user_events_id"]);
                            t.User = new Service.UserClass.User(Convert.ToString(reader["users_name"]));
                            t.Operation.A_number = Convert.ToDouble(reader["a_number"]);
                            t.Operation.B_number = Convert.ToDouble(reader["b_number"]);
                            t.Operation.Result = Convert.ToDouble(reader["result"]);
                            t.DateTimeOperation = Convert.ToDateTime(reader["dattim"]);
                            list_events.Add(t);

                        }
                        return list_events;
                    }
                    else
                        throw new Exception("В базе нет событий с данным IP "+user_ip);
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }
                

            }
        }

        public void InsertEventIntoDatabase(string user_name,char operation_char, double a_number, double b_number, double result, DateTime dattim)
        {
            using (SqlConnection conn = CONNECTION)
            {
            //    try
            //    {
                    conn.Open();
                    SqlCommand insert_command = new SqlCommand("dbo.INS_USER_EVENT", conn);
                    insert_command.CommandType = CommandType.StoredProcedure;
                    SqlParameter user_name_parameter = new SqlParameter
                    {
                        ParameterName = "@user_name",
                        Value = user_name,
                        SqlDbType = SqlDbType.VarChar
                    };
                    SqlParameter operation_char_parameter = new SqlParameter
                    {
                        ParameterName = "@operation_char",
                        Value = operation_char,
                        SqlDbType = SqlDbType.Char
                    };
                    SqlParameter a_number_parameter = new SqlParameter
                    {
                        ParameterName = "@a_number",
                        Value = a_number,
                        SqlDbType = SqlDbType.Decimal
                    };
                    SqlParameter b_number_parameter = new SqlParameter
                    {
                        ParameterName = "@b_number",
                        Value = b_number,
                        SqlDbType = SqlDbType.Decimal
                    };
                    SqlParameter result_parameter = new SqlParameter
                    {
                        ParameterName = "@result",
                        Value = result,
                        SqlDbType = SqlDbType.Decimal
                    };
                    SqlParameter dattim_parameter = new SqlParameter
                    {
                        ParameterName = "@dattim",
                        Value = dattim,
                        SqlDbType = SqlDbType.DateTime2
                    };
                    insert_command.Parameters.Add(user_name_parameter);
                    insert_command.Parameters.Add(operation_char_parameter);
                    insert_command.Parameters.Add(a_number_parameter);
                    insert_command.Parameters.Add(b_number_parameter);
                    insert_command.Parameters.Add(result_parameter);
                    insert_command.Parameters.Add(dattim_parameter);
                    int a = insert_command.ExecuteNonQuery();
                //}
                //catch(Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //    throw;
                //}
            }


        }
    }
}