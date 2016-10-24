using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace App_Code
{
    public sealed class DatabaseExec
    {
        public static string DatabaseConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; }
        }

        public static string[] ListTags()
        {
            DataSet tags = ExecuteQuery("ListTags", new string[0], new object[0]);
            string[] s = new string[tags.Tables[0].Rows.Count];
            for (int i = 0; i < tags.Tables[0].Rows.Count; ++i)
            {
                s[i] = tags.Tables[0].Rows[i]["Tag"].ToString();
            }
            return s;
        }

        public static int ExecuteNonQuery(string procedureName, string[] paramNames, object[] values)
        {
            //try
            //{
            using (SqlConnection SqlConn = new SqlConnection(DatabaseConnectionString))
            {
                using (SqlCommand SqlCmd = new SqlCommand())
                {
                    SqlCmd.Connection = SqlConn;
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.CommandText = procedureName;
                    for (int i = 0; i < paramNames.Length; ++i)
                    {
                        SqlParameter SqlParam = new SqlParameter();
                        SqlParam.ParameterName = paramNames[i];
                        SqlParam.Value = values[i];
                        SqlCmd.Parameters.Add(SqlParam);
                    }
                    SqlConn.Open();
                    int reslt = SqlCmd.ExecuteNonQuery();
                    SqlConn.Close();
                    return reslt;
                }
            }
            //}
            //catch { return -1; }
        }


        public static DataSet ExecuteQuery(string procedureName, string[] paramNames, object[] values)
        {
            DataSet reslt = new DataSet();
            using (SqlConnection SqlConn = new SqlConnection(DatabaseConnectionString))
            {
                using (SqlCommand SqlCmd = new SqlCommand())
                {
                    SqlCmd.Connection = SqlConn;
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.CommandText = procedureName;
                    for (int i = 0; i < paramNames.Length; ++i)
                    {
                        SqlParameter SqlParam = new SqlParameter();
                        SqlParam.ParameterName = paramNames[i];
                        SqlParam.Value = values[i];
                        SqlCmd.Parameters.Add(SqlParam);
                    }
                    SqlDataAdapter Adapt = new SqlDataAdapter(SqlCmd);
                    Adapt.Fill(reslt);
                }
            }
            return reslt;
        }

        /*SqlCmd.Connection = SqlConn;
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.CommandText = procedureName;
                    for (int i = 0; i < paramNames.Length; ++i)
                    {
                        SqlParameter SqlParam = new SqlParameter();
                        SqlParam.ParameterName = paramNames[i];
                        SqlParam.Value = values[i];
                        SqlCmd.Parameters.Add(SqlParam);
                    }
                    SqlDataAdapter Adapt = new SqlDataAdapter(SqlCmd);
                    Adapt.Fill(reslt);*/

        public static object ExecuteScalar(string procedureName, string[] paramNames, object[] values)
        {
            object reslt;
            using (SqlConnection SqlConn = new SqlConnection(DatabaseConnectionString))
            {
                using (SqlCommand SqlCmd = new SqlCommand())
                {
                    SqlCmd.Connection = SqlConn;
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.CommandText = procedureName;
                    for (int i = 0; i < paramNames.Length; ++i)
                    {
                        SqlParameter SqlParam = new SqlParameter();
                        SqlParam.ParameterName = paramNames[i];
                        SqlParam.Value = values[i];
                        SqlCmd.Parameters.Add(SqlParam);
                    }
                    SqlConn.Open();
                    reslt = SqlCmd.ExecuteScalar();
                    SqlCmd.Connection.Close();
                }
            }
            return reslt;
        }


        public static int CreatePhotoForPerson(string personName, string description, int accessLevel, byte[] photo)
        {
            string[] Parames = new string[]
                {
                    "@Title",
                    "@Description",
                    "@IsText",
                    "@ImageBody",
                    "@AccessLevel",
                    "@CertainLevel",
                    "@DocumentID"
                };
            object[] Vals = new object[]
                {
                    personName,
                    description,
                    0,
                    photo,
                    accessLevel,
                    0,
                    null
                };

            int NewDocID =
                Convert.ToInt32(ExecuteScalar("SaveDocument", Parames, Vals));
            return NewDocID;
        }

        public static DataSet SearchPersonWithSiteFilter(string name, int siteID, string lastName, string middleName,
                                                         int start, int count)
        {
            return
                ExecuteQuery("SearchPersonWithSiteFilter",
                             new string[] { "@Title", "@SiteID", "@MiddleName", "@LastName", "@Start", "@Count" },
                             new object[] { name, siteID, lastName, middleName, start, count });
        }

        public static int SavePerson
            (string name,
             string surname,
             string middlename,
             string about,
             object birthDate,
             bool isOrganization,
             int personPhotoID,
             string position,
             object personID)
        {
            string[] Parameters = new string[]
                {
                    "@FirstName",
                    "@LastName",
                    "@MiddleNames",
                    "@About",
                    "@BirthDate",
                    "@IsOrganization",
                    "@PersonPhotoID",
                    "@PersonPosition",
                    "@PersonID"
                };
            object[] Values = new object[]
                {
                    name,
                    surname,
                    middlename,
                    about,
                    birthDate,
                    isOrganization,
                    personPhotoID,
                    position,
                    personID
                };
            return Convert.ToInt32(ExecuteScalar("SavePerson", Parameters, Values));
        }

        public static int GetPersonPhotoID(int personID)
        {
            string[] Param = new string[] { "@PersonID" };
            object[] Value = new object[] { personID };
            return Convert.ToInt32(ExecuteScalar("GetPersonPhotoID", Param, Value));
        }

        public static string GetDocumentTitle(int documentID)
        {
            return ExecuteScalar("GetDocumentTitle", new string[] { "@DocumentID" }, new object[] { documentID }).ToString();
        }

        public static DataRow GetPersonPrimaryData(int personID)
        {
            DataSet PersonData = ExecuteQuery("GetPersonPrimaryData", new string[] { "@PersonID" }, new object[] { personID });
            return PersonData.Tables[0].Rows[0];
        }


        public static DataSet ListLinkTableByDocument(string table, int documentID)
        {
            return
                ExecuteQuery("ListLinkTableByDocument", new string[] { "@DocumentID", "@Tablename" },
                             new object[] { documentID, table });
        }

        public static DataSet ListLinkTableByPerson(string table, int personID)
        {
            return
                ExecuteQuery("ListLinkTableByPerson", new string[] { "@PersonID", "@Tablename" },
                             new object[] { personID, table });
        }

        public static void AddLinkTableValue(string linkTable, object personID, int documentID, string personFi)
        {
            ExecuteNonQuery("AddDocumentPoint", new string[] { "@Table", "@PersonID", "@DocumentID", "@PersonFi" },
                            new object[] { linkTable, personID, documentID, personFi });
        }

        public static void RemoveLinkTableValue(string linkTable, int personID, int documentID)
        {
            ExecuteNonQuery("RemoveDocumentPoint", new string[] { "@Table", "@PersonID", "@DocumentID" },
                            new object[] { linkTable, personID, documentID });
        }

        public static void AddDocumentPhoto(int documentID, int photoID)
        {
            ExecuteNonQuery("AddDocumentPhoto", new string[] { "@DocumentID", "@PhotoID" }, new object[] { documentID, photoID });
        }

        public static void RemoveDocumentPhoto(int documentID, int photoID)
        {
            ExecuteNonQuery("RemoveDocumentPhoto", new string[] { "@DocumentID", "@PhotoID" },
                            new object[] { documentID, photoID });
        }

        public static int SaveDocument
            (object actualDate,
             string creatorID,
             string title,
             string description,
             string documentBody,
             string sourceInet,
             string sourceMassMedia,
             string sourceOfficial,
             int certainLevel,
             int accessLevel,
             string cost,
             int locationID,
             object documentID)
        {
            string[] DocParamNames = new string[]
                {
                    "@ActualDate",
                    "@CreatorID",
                    "@Title",
                    "@Description",
                    "@DocumentBody",
                    "@sourceInet",
                    "@SourceMassMedia",
                    "@SourceOfficial",
                    "@CertainLevel",
                    "@AccessLevel",
                    "@Cost",
                    "@IsText",
                    "@LocationID",
                    "@DocumentID"
                };
            object[] DocParams = new object[]
                {
                    actualDate,
                    creatorID,
                    title,
                    description,
                    documentBody,
                    sourceInet,
                    sourceMassMedia,
                    sourceOfficial,
                    certainLevel,
                    accessLevel,
                    cost,
                    1,
                    locationID,
                    documentID
                };
            return Convert.ToInt32(ExecuteScalar("SaveDocument", DocParamNames, DocParams));
        }

        public static DataSet GetDocumentByID(int documentID)
        {
            return ExecuteQuery("GetDocument", new string[] { "@DocumentID" }, new object[] { documentID });
        }

        public static string GetTownByID(int townID)
        {
            return ExecuteScalar("GetTownByID", new string[] { "@TownID" }, new object[] { townID }).ToString();
        }

        public static string GetRegionByID(int regionID)
        {
            return ExecuteScalar("GetRegionByID", new string[] { "@RegionID" }, new object[] { regionID }).ToString();
        }

        public static string GetLocationString(object locationID)
        {
            return ExecuteScalar("GetLocationString", new string[] { "@LocationID" }, new object[] { locationID }).ToString();
        }

        public static DataSet SearchPerson(object firstName,
                                           object lastName,
                                           object middleNames,
                                           object isOrganisation,
                                           string leftDay, string leftMonth, string leftYear,
                                           string rightDay, string rightMonth, string rightYear,
                                           string personPosition)
        {
            String LeftDate = leftYear + "-" + leftMonth + "-" + leftDay;
            String RightDate = rightYear + "-" + rightMonth + "-" + rightDay;
            if ((LeftDate.Contains("--")) ^ (RightDate.Contains("--")))
                if (LeftDate.Contains("--")) LeftDate = RightDate;
                else RightDate = LeftDate;
            else if ((LeftDate.Contains("--")) && (RightDate.Contains("--")))
            {
                RightDate = null;
                LeftDate = null;
            }
            firstName = "%" + firstName + "%";
            lastName = "%" + lastName + "%";
            middleNames = "%" + middleNames + "%";
            return ExecuteQuery("SearchPerson",
                                new string[]
                                    {
                                        "@Firstname",
                                        "@LastName",
                                        "@MiddleName",
                                        "@IsOrganisation",
                                        "@LeftDate",
                                        "@RightDate",
                                        "@PersonPosition"
                                    },
                                new object[]
                                    {
                                        firstName,
                                        lastName,
                                        middleNames,
                                        isOrganisation,
                                        LeftDate,
                                        RightDate,
                                        personPosition
                                    });
        }

        public static void DeletePerson(int personID)
        {
            ExecuteNonQuery("RemovePerson", new string[] { "@PersonID" }, new object[] { personID });
        }

        public static void AddTag(string tag)
        {
            ExecuteNonQuery("AddTag", new string[] { "@Tag" }, new object[] { tag });
        }

        public static void RemoveTag(int tagID)
        {
            ExecuteNonQuery("RemoveTag", new string[] { "@TagID" }, new object[] { tagID });
        }

        public static String GetDocumentAccessLevel(int documentID)
        {
            int AccessLevel =
                (int)ExecuteScalar("GetDocumentAccessLevel", new string[] { "@DocumentID" }, new object[] { documentID });
            switch (AccessLevel)
            {
                case 0:
                    return "User";
                case 1:
                    return "Candidate";
                case 2:
                    return "Expert";
                case 3:
                    return "Analytic";
            }
            return "User";
        }

        public static DataSet SearchDocument(string title, string linkMassMedia, string linkOfficial, string linkInternet,
                                             string creatorName, string cLeftDay, string cLeftMonth, string cLeftYear,
                                             string cRightDay, string cRightMonth, string cRightYear, string aLeftDay,
                                             string aLeftMonth, string aLeftYear, string aRightDay, string aRightMonth,
                                             string aRightYear, int cost, string bodyWords, string descriptWords,
                                             int locationID, int regionID)
        {
            String CLeftDate = cLeftYear + "-" + cLeftMonth + "-" + cLeftDay;
            String CRightDate = cRightYear + "-" + cRightMonth + "-" + cRightDay;
            if ((CLeftDate.Contains("--")) ^ (CRightDate.Contains("--")))
                if (CLeftDate.Contains("--")) CLeftDate = CRightDate;
                else CRightDate = CLeftDate;
            else if ((CLeftDate.Contains("--")) && (CRightDate.Contains("--")))
            {
                CRightDate = "";
                CLeftDate = "";
            }

            String ALeftDate = aLeftYear + "-" + aLeftMonth + "-" + aLeftDay;
            String ARightDate = aRightYear + "-" + aRightMonth + "-" + aRightDay;
            if ((ALeftDate.Contains("--")) ^ (ARightDate.Contains("--")))
                if (ALeftDate.Contains("--")) ALeftDate = ARightDate;
                else ARightDate = ALeftDate;
            else if ((ALeftDate.Contains("--")) && (ARightDate.Contains("--")))
            {
                ARightDate = "";
                ALeftDate = "";
            }
            bodyWords.Replace(" ", "%");
            descriptWords.Replace(" ", "%");
            string[] Params = new string[]
                {
                    "@Title",
                    "@LinkMassMedia",
                    "@LinkOfficial",
                    "@LinkInternet",
                    "@CreatorName",
                    "@CLeftDate",
                    "@CRightDate",
                    "@ALeftDate",
                    "@ARightDate",
                    "@Cost",
                    "@BodyWords",
                    "@DescriptWords",
                    "@LocationID"
                };
            object[] Vals = new object[]
                {
                    title,
                    linkMassMedia,
                    linkOfficial,
                    linkInternet,
                    creatorName,
                    CLeftDate,
                    CRightDate,
                    ALeftDate,
                    ARightDate,
                    cost,
                    bodyWords,
                    descriptWords,
                    locationID,
                };

            return ExecuteQuery("SearchDocument", Params, Vals);
        }

        public static int AddRegion(string region)
        {
            return Convert.ToInt32(ExecuteScalar("AddRegion", new string[] { "@Region" }, new object[] { region }));
        }

        public static void AddTown(string town, int regionID)
        {
            ExecuteNonQuery("AddTown", new string[] { "@Town", "@RegionID" }, new object[] { town, regionID });
        }

        public static void RemoveRegion(int regionID)
        {
            ExecuteNonQuery("RemoveRegion", new string[] { "@RegionID" }, new object[] { regionID });
        }

        public static void RemoveTown(int townID)
        {
            ExecuteNonQuery("RemoveTown", new string[] { "@TownID" }, new object[] { townID });
        }

        //----------
        //Photo Functions
        //----------
        public static void AddPersonPhoto(int personID, int documentID)
        {
            ExecuteNonQuery("AddPersonPhoto", new string[] { "@PersonID", "@DocumentID" }, new object[] { personID, documentID });
        }

        public static void SetFirstPersonPhoto(int personID, int documentID)
        {
            ExecuteNonQuery("SetFirstPersonPhoto", new string[] { "@PersonID", "@DocumentID" },
                            new object[] { personID, documentID });
        }

        public static void SetSecondPersonPhoto(int personID, int documentID)
        {
            ExecuteNonQuery("SetSecondPersonPhoto", new string[] { "@PersonID", "@DocumentID" },
                            new object[] { personID, documentID });
        }

        public static void SetThirdPersonPhoto(int personID, int documentID)
        {
            ExecuteNonQuery("SetThirdPersonPhoto", new string[] { "@PersonID", "@DocumentID" },
                            new object[] { personID, documentID });
        }

        public static void ClearPhoto(int personID, int photonum)
        {
            ExecuteNonQuery("ClearPersonPhoto", new string[] { "@PersonID", "@photonum" }, new object[] { personID, photonum });
        }

        public static void RemovePersonPhoto(int personID, int documentID)
        {
            ExecuteNonQuery("RemovePersonPhoto", new string[] { "@PersonID", "@DocumentID" },
                            new object[] { personID, documentID });
        }

        public static void RemoveDocumentTag(int documentID, int tagID)
        {
            ExecuteNonQuery("RemoveDocumentTag", new string[] { "@DocumentID", "@TagID" }, new object[] { documentID, tagID });
        }

        public static void RemoveDocumentTag(int documentID, string tag)
        {
            ExecuteNonQuery("RemoveDocumentTag", new string[] { "@DocumentID", "@Tag" }, new object[] { documentID, tag });
        }

        //----------
        //SoAPSites
        //----------


        public static string GetSitePublicKey(int siteID)
        {
            return ExecuteScalar("GetSitePublicKey", new string[] { "@SiteID" }, new object[] { siteID }).ToString();
        }

        public static void SetSiteEnabled(bool enabled, int siteID)
        {
            ExecuteNonQuery("SetSiteEnabled", new string[] { "@Enabled", "@SiteID" }, new object[] { enabled, siteID });
        }

        public static void SetSiteBalance(int siteID, float balance)
        {
            ExecuteNonQuery("setSiteBalance", new string[] { "@SiteID", "@Balance" }, new object[] { siteID, balance });
        }

        public static void CreateSite(object siteID, string siteName, string comment, string publicKey, SqlMoney balance,
                                      bool enabled)
        {
            string[] Params = new string[]
                {
                    "@SiteID",
                    "@SiteName",
                    "@PublicKey",
                    "@Balance",
                    "@Enabled",
                    "@Comment"
                };

            object[] Vals = new object[]
                {
                    siteID,
                    siteName,
                    publicKey,
                    balance,
                    enabled,
                    comment,
                };
            ExecuteNonQuery("SaveSite", Params, Vals);
        }

        public static void RemoveSite(int siteID)
        {
            ExecuteNonQuery("RemoveSite", new string[] { "@SiteID" }, new object[] { siteID });
        }

        public static DataSet SearchDocumentWithSiteFilter(
            string title, string body, int siteID, int start, int count)
        {
            string[] Param = new string[]
                {
                    "@Title",
                    "@Body",
                    "@SiteID",
                    "@Start",
                    "@Count"
                };
            object[] Values = new object[]
                {
                    title,
                    body,
                    siteID,
                    start,
                    count
                };
            return ExecuteQuery("SearchDocumentWithSiteFilter", Param, Values);
        }


        public static int UpdatePerson(int personID, string name, string surname, string middlename, string about,
                                       DateTime birthDate,
                                       bool isOrganization, int personPhotoID, string position)
        {
            string[] Parameters = new string[]
                {
                    "@PersonID",
                    "@FirstName",
                    "@LastName",
                    "@MiddleNames",
                    "@About",
                    "@BirthDate",
                    "@IsOrganization",
                    "@PersonPhotoID",
                    "@PersonPosition"
                };
            object[] Values = new object[]
                {
                    personID,
                    name,
                    surname,
                    middlename,
                    about,
                    birthDate,
                    isOrganization,
                    personPhotoID,
                    position
                };
            return Convert.ToInt32(ExecuteScalar("SavePerson", Parameters, Values));
        }

        public static int GetRegionByTownID(int townID)
        {
            return Convert.ToInt32(ExecuteScalar("GetRegionByTownID", new string[] { "@TownID" }, new object[] { townID }));
        }

        public static void UserBan(string userName, bool setLockout)
        {
            ExecuteNonQuery("UserBan", new string[] { "@UserName", "@SetLockedOut" }, new object[] { userName, setLockout });
        }

        public static void RemoveDocument(int dosumentID)
        {
            ExecuteNonQuery("RemoveDocument", new string[] { "@DocumentID" }, new object[] { dosumentID });
        }

        public static void SetDocumentAccessLevel(int documentID, int accessLevel)
        {
            ExecuteNonQuery("SetAccessLevel", new string[] { "@DocumentID", "@AccessLevel" },
                            new object[] { documentID, accessLevel });
        }

        public static void SetPhotoInfo(int documentID, string title, string description)
        {
            ExecuteNonQuery("UpdatePhotoInfo", new string[] { "@DocumentID", "@Title", "@Description" },
                            new object[] { documentID, title, description });
        }

        public static bool IsCreatorFiltered(string userName, int siteID)
        {
            return
                Convert.ToBoolean(
                    ExecuteScalar("IsCreatorFiltered", new string[] { "@UserName", "@SiteID" },
                                  new object[] { userName, siteID }));
        }

        public static bool IsDocumentFiltered(int documentID, int siteID)
        {
            return
                Convert.ToBoolean(
                    ExecuteScalar("IsDocumentFiltered", new string[] { "@DocumentID", "@SiteID" },
                                  new object[] { documentID, siteID }));
        }

        public static bool IsPersonFiltered(int personID, int siteID)
        {
            return
                Convert.ToBoolean(
                    ExecuteScalar("IsPersonFiltered", new string[] { "@PersonID", "@SiteID" }, new object[] { personID, siteID }));
        }

        public static void AddSiteFilter(object siteID, object documentID, object personID, string userName)
        {
            string[] Params = new string[]
                {
                    "@SiteID",
                    "@DocumentID",
                    "@PersonID",
                    "@UserName"
                };
            object[] Values = new object[]
                {
                    siteID,
                    documentID,
                    personID,
                    userName
                };
            ExecuteNonQuery("AddSiteFilter", Params, Values);
        }

        public static void SetSitePublicKey(string publicKey, int siteID)
        {
            ExecuteNonQuery("SetSitePublicKey", new string[] { "@SiteID", "@PublicKey" }, new object[] { siteID, publicKey });
        }

        public static void AcceptOfferedTag(string tag)
        {
            ExecuteNonQuery("AcceptOfferedTag", new string[] { "@Tag" }, new object[] { tag });
        }

        public static DataSet GenTagWeightTable()
        {
            return ExecuteQuery("GenTagWeightTable", new string[0], new object[0]);
        }

        public static void AddOrCreateDocumentTags(string tagString, int documentID)
        {
            string[] TagList = tagString.Split(',');
            foreach (string s in TagList)
            {
                if (s.Trim() != "")
                    ExecuteQuery("AddOrCreateTag", new string[] { "@Tag", "@DocumentID" },
                                 new object[] { s.Trim().ToLower(), documentID });
            }
        }

        public static DataSet SearchDocumentByTag(string tag)
        {
            return ExecuteQuery("SearchDocumentByTag", new string[] { "@Tag" }, new object[] { tag });
        }

        public static void StoreDocumentPerson(int documentID, string firstName, string lastName, bool isOrganisation)
        {
            ExecuteNonQuery("StoreDocumentPerson",
                            new string[] { "@DocumentID", "@FirstName", "@LastName", "@IsOrganisation" },
                            new object[] { documentID, firstName, lastName, isOrganisation });
        }

        public static void UnStoreDocumentPerson(int documentID, string personFI)
        {
            ExecuteNonQuery("UnStoreDocumentPerson", new string[] { "@DocumentID", "@PersonFI" },
                            new object[] { documentID, personFI });
        }

        public static void SavePersonPosition(int personID, string creatorNick, string newPersonPosition, int documentID,
                                              bool assigned)
        {
            string[] Params = new string[]
                {
                    "@PersonID",
                    "@CreatorNick",
                    "@NewPersonPosition",
                    "@PointingDocumentID",
                    "@Assigned"
                };
            object[] Vals = new object[]
                {
                    personID,
                    creatorNick,
                    newPersonPosition,
                    documentID,
                    assigned
                };

            ExecuteNonQuery("SetPersonPosition", Params, Vals);
        }

        public static string GetPersonFio(int personID)
        {
            return ExecuteScalar("GetPersonFio", new string[] { "@PersonID" }, new object[] { personID }).ToString();
        }

        public static string GetTagString(int documentID)
        {
            using (DataSet ds = ExecuteQuery("ListDocumentTags", new string[] { "@DocumentID" }, new object[] { documentID }))
            {
                string s = "";
                for (int i = 0; i < ds.Tables[0].Rows.Count; ++i)
                {
                    s = s + ds.Tables[0].Rows[i]["Tag"] + ", ";
                }
                return s;
            }
        }

        public static DataSet GetDocumentConflictOrLink(int personID, int documentID, bool isConflict)
        {
            using (
                DataSet ds =
                    ExecuteQuery("GetDocumentConflictOrLink", new string[] { "@PersonID", "@DocumentID", "IsConflict" },
                                 new object[] { personID, documentID, isConflict }))
            {
                DataSet reslt = new DataSet();
                reslt.Tables.Add();
                reslt.Tables[0].Columns.Add("Fio");
                reslt.Tables[0].Columns.Add("PersonID");
                for (int i = 0; i < ds.Tables[0].Rows.Count; ++i)
                {
                    int pid = Convert.ToInt32(ds.Tables[0].Rows[i]["LeftPersonID"]);
                    if (pid != personID) reslt.Tables[0].Rows.Add(new object[] { GetPersonFio(pid), pid });
                    pid = Convert.ToInt32(ds.Tables[0].Rows[i]["RightPersonID"]);
                    if (pid != personID) reslt.Tables[0].Rows.Add(new object[] { GetPersonFio(pid), pid });
                }
                return reslt;
            }
        }

        public static void CreateConflictOrLink(int documentID, int leftPersonID, int rightPersonID, bool isConflict)
        {
            if (rightPersonID == leftPersonID) return;
            if (rightPersonID > leftPersonID)
            {
                rightPersonID = rightPersonID + leftPersonID;
                leftPersonID = rightPersonID - leftPersonID;
                rightPersonID = rightPersonID - leftPersonID;
            }

            ExecuteNonQuery("CreateConflictOrLink",
                            new string[] { "@DocumentID", "@LeftPersonID", "@RightPersonID", "@IsConflict" },
                            new object[] { documentID, leftPersonID, rightPersonID, isConflict });
        }

        public static void RemoveConflictOrLink(int documentID, int leftPersonID, int rightPersonID, bool isConflict)
        {
            if (rightPersonID == leftPersonID) return;
            if (rightPersonID > leftPersonID)
            {
                rightPersonID = rightPersonID + leftPersonID;
                leftPersonID = rightPersonID - leftPersonID;
                rightPersonID = rightPersonID - leftPersonID;
            }

            ExecuteNonQuery("RemoveConflictOrLink",
                            new string[] { "@DocumentID", "@LeftPersonID", "@RightPersonID", "@IsConflict" },
                            new object[] { documentID, leftPersonID, rightPersonID, isConflict });
        }

        public static string ListDocumentLinksOrConflicts(int documentID, bool isConflict)
        {
            string l = "";
            using (
                DataSet ds =
                    ExecuteQuery("ListDocumentLinksOrConflicts", new string[] { "@DocumentID", "@IsConflict" },
                                 new object[] { documentID, isConflict }))
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; ++i)
                {
                    int lpid = Convert.ToInt32(ds.Tables[0].Rows[i]["LeftPersonID"]);
                    int rpid = Convert.ToInt32(ds.Tables[0].Rows[i]["RightPersonID"]);
                    l += "<a href='/view/Dossie.aspx?id=" + lpid + "'>" + GetPersonFio(lpid) +
                         "</a> - <a href='/View/Dossie.aspx?id=" + rpid + "'>" + GetPersonFio(rpid) + "</a><br/>";
                }
                return l;
            }
        }

        public static DataSet ListPersonConflictsOrLinks(int personID, bool isConflict)
        {
            DataSet ds =
                ExecuteQuery("ListPersonConflictsOrLinks", new string[] { "@PersonID", "@IsConflict" },
                             new object[] { personID, isConflict });
            DataSet reslt = new DataSet();
            reslt.Tables.Add();
            reslt.Tables[0].Columns.Add("Document");
            reslt.Tables[0].Columns.Add("Fio");
            reslt.Tables[0].Columns.Add("DocumentID");
            reslt.Tables[0].Columns.Add("PersonID");
            int cdid;
            for (int i = 0; i < ds.Tables[0].Rows.Count; ++i)
            {
                int cpid = Convert.ToInt32(ds.Tables[0].Rows[i]["LeftPersonID"]) == personID
                               ? Convert.ToInt32(ds.Tables[0].Rows[i]["RightPersonID"])
                               : Convert.ToInt32(ds.Tables[0].Rows[i]["LeftPersonID"]);
                cdid = Convert.ToInt32(ds.Tables[0].Rows[i]["DocumentID"]);
                reslt.Tables[0].Rows.Add(GetDocumentTitle(cdid), GetPersonFio(cpid), cdid, cpid);
            }
            return reslt;
        }

        public static DataSet ListDocumentFotogalery(int documentID)
        {
            return ExecuteQuery("ListDocumentFotogalery", new string[] { "@DocumentID" }, new object[] { documentID });
        }
        public static void CreatePosition(string name, String aliases)
        {
            int primaryId = Convert.ToInt32(ExecuteQuery("CreatePosition", new string[] { "@Position" }, new object[] { name }).Tables[0].Rows[0][0]);
            int aliasId = 0;
            String[] aliasesToAdd = aliases.Split(',');
            foreach (string s in aliasesToAdd)
            {
                if (!s.Trim().Equals(""))
                {
                    aliasId =
                       Convert.ToInt32(
                        ExecuteQuery("CreatePosition", new string[] {"@Position"}, new object[] {s.Trim()}).Tables[0].
                            Rows[0][0]);
                    ExecuteNonQuery("AddPositionAlias", new string[] {"@PrimaryId", "@AliasId"},
                                    new object[] {primaryId, aliasId});
                }
            }
        }

        public static void AddBiographyEntry(int personId, object positionId,SqlDateTime changeDate,object documentId,object isAccepted)
        {
            ExecuteNonQuery("AddBiographyEntry",
                            new string[] {"@PersonId", "@PositionId", "@ChangeDate", "@DocumentId", "@IsAccepted"},
                            new object[] {personId, positionId, changeDate, documentId, isAccepted});
        }
    }
}