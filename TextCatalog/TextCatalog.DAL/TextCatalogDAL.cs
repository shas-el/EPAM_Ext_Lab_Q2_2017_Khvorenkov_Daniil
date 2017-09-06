namespace TextCatalog.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.Sql;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TextCatalog.DAL.Model;

    public class TextCatalogDAL
    {
        public List<Text> GetTexts()
        {
            List<Text> result = new List<Text>();

            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetTexts";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Text text = new Text()
                        {
                            TextId = (int)reader["TextId"],
                            TextTitle = (string)reader["TextTitle"],
                            TextDescription = (string)reader["TextDescription"],
                            UploaderId = (int)reader["UploaderId"],
                            UploadDate = (DateTime)reader["UploadDate"],
                            FileName = (string)reader["FileName"],
                            SectionId = (int)reader["SectionId"]
                        };

                        result.Add(text);
                    }
                }

                connection.Close();
            }

            return result;
        }

        public Text GetTextById(int id)
        {
            Text result;

            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetTextById";
                ((SqlCommand)command).Parameters.AddWithValue("@textId", id);

                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    result = new Text()
                    {
                        TextId = (int)reader["TextId"],
                        TextTitle = (string)reader["TextTitle"],
                        TextDescription = (string)reader["TextDescription"],
                        UploaderId = (int)reader["UploaderId"],
                        UploadDate = (DateTime)reader["UploadDate"],
                        FileName = (string)reader["FileName"],
                        SectionId = (int)reader["SectionId"]
                    };
                }

                connection.Close();
            }

            return result;
        }

        public List<Text> GetTexts(TextQueryParams queryParams)
        {
            List<Text> result = new List<Text>();

            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetTextsQuery";
                ((SqlCommand)command).Parameters.AddWithValue("@titleString", queryParams.Title);
                ((SqlCommand)command).Parameters.AddWithValue("@descrString", queryParams.Description);
                ((SqlCommand)command).Parameters.AddWithValue("@sectionId", queryParams.SectionId);
                ((SqlCommand)command).Parameters.AddWithValue("@beginDate", queryParams.BeginDate);
                ((SqlCommand)command).Parameters.AddWithValue("@endDate", queryParams.EndDate);
                ((SqlCommand)command).Parameters.AddWithValue("@uploaderId", queryParams.UploaderId);

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Text text = new Text()
                        {
                            TextId = (int)reader["TextId"],
                            TextTitle = (string)reader["TextTitle"],
                            TextDescription = (string)reader["TextDescription"],
                            UploaderId = (int)reader["UploaderId"],
                            UploadDate = (DateTime)reader["UploadDate"],
                            FileName = (string)reader["FileName"],
                            SectionId = (int)reader["SectionId"]
                        };

                        result.Add(text);
                    }
                }

                connection.Close();
            }

            return result;
        }

        public List<Text> GetTopTexts()
        {
            List<Text> result = new List<Text>();

            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetTopTwentyTexts";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Text text = new Text()
                        {
                            TextId = (int)reader["TextId"],
                            TextTitle = (string)reader["TextTitle"],
                            TextDescription = (string)reader["TextDescription"],
                            UploaderId = (int)reader["UploaderId"],
                            UploadDate = (DateTime)reader["UploadDate"],
                            FileName = (string)reader["FileName"],
                            SectionId = (int)reader["SectionId"]
                        };

                        result.Add(text);
                    }
                }

                connection.Close();
            }

            return result;
        }

        public void CreateText(Text text)
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateText";
                ((SqlCommand)command).Parameters.AddWithValue("@textTitle", text.TextTitle);
                ((SqlCommand)command).Parameters.AddWithValue("@textDescription", text.TextDescription);
                ((SqlCommand)command).Parameters.AddWithValue("@uploaderId", text.UploaderId);
                ((SqlCommand)command).Parameters.AddWithValue("@uploadDate", text.UploadDate);
                ((SqlCommand)command).Parameters.AddWithValue("@fileName",
                    text.UploaderId.ToString() + text.TextTitle + text.UploadDate.ToString());
                ((SqlCommand)command).Parameters.AddWithValue("@sectionId", text.SectionId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void UpdateText(Text text)
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateText";
                ((SqlCommand)command).Parameters.AddWithValue("@textId", text.TextId);
                ((SqlCommand)command).Parameters.AddWithValue("@textTitle", text.TextTitle);
                ((SqlCommand)command).Parameters.AddWithValue("@textDescription", text.TextDescription);
                ((SqlCommand)command).Parameters.AddWithValue("@uploaderId", text.UploaderId);
                ((SqlCommand)command).Parameters.AddWithValue("@uploadDate", text.UploadDate);
                ((SqlCommand)command).Parameters.AddWithValue("@fileName", text.FileName);
                ((SqlCommand)command).Parameters.AddWithValue("@sectionId", text.SectionId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void DeleteText(Text text)
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteText";
                ((SqlCommand)command).Parameters.AddWithValue("@textId", text.TextId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void CreateRating(Rating rating)
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateRating";
                ((SqlCommand)command).Parameters.AddWithValue("@userId", rating.UserId);
                ((SqlCommand)command).Parameters.AddWithValue("@textId", rating.TextId);
                ((SqlCommand)command).Parameters.AddWithValue("@positive", rating.Positive);
                ((SqlCommand)command).Parameters.AddWithValue("@ratingDate", rating.RatingDate);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void DeleteRating(Rating rating)
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteRating";
                ((SqlCommand)command).Parameters.AddWithValue("@userId", rating.UserId);
                ((SqlCommand)command).Parameters.AddWithValue("@textId", rating.TextId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public bool CheckRating(Rating rating)
        {
            bool result;

            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetRating";
                ((SqlCommand)command).Parameters.AddWithValue("@userId", rating.UserId);
                ((SqlCommand)command).Parameters.AddWithValue("@textId", rating.TextId);

                using (IDataReader reader = command.ExecuteReader())
                {
                    result = reader.Read();
                }

                connection.Close();
            }

            return result;
        }

        public User GetUserDetails(User user)
        {
            User result;

            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUserByNamePassword";
                ((SqlCommand)command).Parameters.AddWithValue("@userName", user.UserName);
                ((SqlCommand)command).Parameters.AddWithValue("@password", user.Password);

                using (IDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        connection.Close();
                        return null;
                    }

                    result = new User()
                    {
                        UserId = (int)reader["UserId"],
                        UserName = (string)reader["UserName"],
                        Password = (string)reader["Password"],
                        RoleId = (int)reader["RoleId"]
                    };
                }

                connection.Close();
            }

            return result;
        }

        public List<Text> GetUploaderTexts(User uploader)
        {
            List<Text> result = new List<Text>();

            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetTextsQuery";
                ((SqlCommand)command).Parameters.AddWithValue("@uploaderId", uploader.UserId);

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Text text = new Text()
                        {
                            TextId = (int)reader["TextId"],
                            TextTitle = (string)reader["TextTitle"],
                            TextDescription = (string)reader["TextDescription"],
                            UploaderId = (int)reader["UploaderId"],
                            UploadDate = (DateTime)reader["UploadDate"],
                            FileName = (string)reader["FileName"],
                            SectionId = (int)reader["SectionId"]
                        };

                        result.Add(text);
                    }
                }

                connection.Close();
            }

            return result;
        }

        public User GetUserDetailsName(User user)
        {
            User result;

            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUserByName";
                ((SqlCommand)command).Parameters.AddWithValue("@userName", user.UserName);

                using (IDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        connection.Close();
                        return null;
                    }

                    result = new User()
                    {
                        UserId = (int)reader["UserId"],
                        UserName = (string)reader["UserName"],
                        Password = (string)reader["Password"],
                        RoleId = (int)reader["RoleId"]
                    };
                }

                connection.Close();
            }

            return result;
        }

        public void CreateUser(User user)
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateUser";
                ((SqlCommand)command).Parameters.AddWithValue("@userName", user.UserName);
                ((SqlCommand)command).Parameters.AddWithValue("@password", user.Password);
                ((SqlCommand)command).Parameters.AddWithValue("@roleId", user.RoleId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public List<Section> GetSectionAndDescendants(Section section)
        {
            List<Section> result = new List<Section>();

            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetSectionAndDescendants";
                ((SqlCommand)command).Parameters.AddWithValue("@sectionId", section.SectionId);

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Section s = new Section()
                        {
                            SectionId = (int)reader["SectionId"],
                            SectionName = (string)reader["SectionName"],
                            ParentSectionId = (reader["ParentSectionId"] == DBNull.Value)
                                ? null : (int?)reader["ParentSectionId"]
                        };

                        result.Add(s);
                    }
                }

                connection.Close();
            }

            return result;
        }

        public Section GetRootSection()
        {
            Section result;

            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetRootSection";

                using (IDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        connection.Close();
                        return null;
                    }

                    result = new Section()
                    {
                        SectionId = (int)reader["SectionId"],
                        SectionName = (string)reader["SectionName"],
                        ParentSectionId = (reader["ParentSectionId"] == DBNull.Value)
                                ? null : (int?)reader["ParentSectionId"]
                    };
                }

                connection.Close();
            }

            return result;
        }

        public List<Tag> GetTags()
        {
            List<Tag> result = new List<Tag>();

            var connectionStringItem = ConfigurationManager.ConnectionStrings["TextDbConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetTags";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tag tag = new Tag()
                        {
                            TagId = (int)reader["TagId"],
                            TagName = (string)reader["TagName"],
                            TagDescription = (string)reader["TagDescription"],
                            CategoryId = (int)reader["CategoryId"]
                        };

                        result.Add(tag);
                    }
                }

                connection.Close();
            }

            return result;
        }
    }
}
