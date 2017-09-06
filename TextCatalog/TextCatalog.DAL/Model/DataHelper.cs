namespace TextCatalog.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class DataHelper
    {
        #region Text

        public static User Uploader(this Text text)
        {
            User uploader;

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
                command.CommandText = "GetUserById";
                ((SqlCommand)command).Parameters.AddWithValue("@userId", text.UploaderId);

                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    uploader = new User()
                    {
                        UserId = (int)reader["UserId"],
                        UserName = (string)reader["UserName"],
                        Password = (string)reader["Password"],
                        RoleId = (int)reader["RoleId"]
                    };
                }

                connection.Close();
            }

            return uploader;
        }

        public static int Likes(this Text text)
        {
            int likes;

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
                command.CommandText = "GetLikes";
                ((SqlCommand)command).Parameters.AddWithValue("@textId", text.TextId);

                likes = (int)command.ExecuteScalar();

                connection.Close();
            }

            return likes;
        }

        public static int Dislikes(this Text text)
        {
            int dislikes;

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
                command.CommandText = "GetDislikes";
                ((SqlCommand)command).Parameters.AddWithValue("@textId", text.TextId);

                dislikes = (int)command.ExecuteScalar();

                connection.Close();
            }

            return dislikes;
        }

        public static Section Section(this Text text)
        {
            Section section;

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
                command.CommandText = "GetSectionById";
                ((SqlCommand)command).Parameters.AddWithValue("@sectionId", text.SectionId);

                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    section = new Section()
                    {
                        SectionId = (int)reader["SectionId"],
                        SectionName = (string)reader["SectionName"],
                        ParentSectionId = (reader["ParentSectionId"] == DBNull.Value) ?
                            null : (int?)reader["ParentSectionId"]
                    };
                }

                connection.Close();
            }

            return section;
        }

        public static List<TagToText> TagConnections(this Text text)
        {
            List<TagToText> result = new List<TagToText>();

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
                command.CommandText = "GetTagToTextByText";
                ((SqlCommand)command).Parameters.AddWithValue("@textId", text.TextId);

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TagToText tagConnection = new TagToText()
                        {
                            TagId = (int)reader["TagId"],
                            TextId = (int)reader["TextId"]
                        };

                        result.Add(tagConnection);
                    }
                }

                connection.Close();
            }

            return result;
        }

        public static List<Tag> Tags(this Text text)
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
                command.CommandText = "GetTagsByText";
                ((SqlCommand)command).Parameters.AddWithValue("@textId", text.TextId);

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

        public static List<Rating> Ratings(this Text text)
        {
            List<Rating> result = new List<Rating>();

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
                command.CommandText = "GetRatingsByText";
                ((SqlCommand)command).Parameters.AddWithValue("@textId", text.TextId);

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rating ratting = new Rating()
                        {
                            UserId = (int)reader["UserId"],
                            TextId = (int)reader["TextId"],
                            Positive = (bool)reader["Positive"],
                            RatingDate = (DateTime)reader["RatingDate"]
                        };

                        result.Add(ratting);
                    }
                }

                connection.Close();
            }

            return result;
        }

        #endregion

        #region User

        public static Role Role(this User user)
        {
            Role role;

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
                command.CommandText = "GetRoleById";
                ((SqlCommand)command).Parameters.AddWithValue("@roleId", user.RoleId);

                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    role = new Role()
                    {
                        RoleId = (int)reader["RoleId"],
                        RoleName = (string)reader["RoleName"]
                    };
                }

                connection.Close();
            }

            return role;
        }

        public static List<Text> Texts(this User user)
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
                ((SqlCommand)command).Parameters.AddWithValue("@uploaderId", user.UserId);

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

        #endregion

        #region Tag

        public static TagCategory TagCategory(this Tag tag)
        {
            TagCategory tagCategory;

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
                command.CommandText = "GetTagCategoryById";
                ((SqlCommand)command).Parameters.AddWithValue("@categoryId", tag.CategoryId);

                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    tagCategory = new TagCategory()
                    {
                        CatgeoryId = (int)reader["CategoryId"],
                        CategoryName = (string)reader["CategoryName"]
                    };
                }

                connection.Close();
            }

            return tagCategory;
        }

        #endregion
    }
}
