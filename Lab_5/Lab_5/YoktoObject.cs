using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Text;
using System.Web.Security;

/// <summary>
/// Summary description for YoktoObject
/// </summary>
namespace ILM.Yokto
{
    public class YoktoObject
    {
        private string name;
        private int id;
        private string description;
        private string culture;
        private double googleLat;
        private double googleLong;
        private bool isService;
        private string location;
        private string contactData;
        private string category;

        public string ThumbImageHref
        {
            get { return thumbImageHref; }
            set { thumbImageHref = value; }
        }

        public string OriginalImageHref
        {
            get { return originalImageHref; }
            set { originalImageHref = value; }
        }

        public string SmallImageHref
        {
            get { return smallImageHref; }
            set { smallImageHref = value; }
        }

        private string thumbImageHref;
        private string originalImageHref;
        private string smallImageHref;

        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }

        private string supplierName;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Culture
        {
            get { return culture; }
            set { culture = value; }
        }

        public double GoogleLat
        {
            get { return googleLat; }
            set { googleLat = value; }
        }

        public double GoogleLong
        {
            get { return googleLong; }
            set { googleLong = value; }
        }

        public bool IsService
        {
            get { return isService; }
            set { isService = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string ContactData
        {
            get { return contactData; }
            set { contactData = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        private int rating;

        private string tags;

        public static void Rate(int objectId, int mark)
        {
            Database.ExecuteNonQuery("RateForObject", new string[] {"@ObjectId", "@Mark", "@UserName"},
                                     new object[] {objectId, mark, Membership.GetUser().UserName});
        }
        public static YoktoObject[] GetUserObjects(string userName)
        {
            int rcnt = 0;
            DataSet userobjects = Search.SearchByString("", DateTime.Today, null, null, false, 0, 0, true,
                                  userName, 100, 0, out rcnt);
            YoktoObject[] result = new YoktoObject[rcnt];
            for (int i=0;i<rcnt;i++)
            {
                result[i] = Get(userobjects, i);
            }
            return result;

        }
        public static DataSet GetObjectDataSet(int objectId, DateTime Day)
        {
            if (Day.Year == 1) Day = DateTime.Now;
            DateTime leftDate = new DateTime(Day.Year, Day.Month, Day.Day, 0, 0, 0);
            DateTime rightDate = new DateTime(Day.Year, Day.Month, Day.Day, 23, 59, 59);

            return
                Database.ExecuteQuery("GetObject", new string[] {"@Id", "@LeftDate", "@RightDate"},
                                      new object[] {objectId, new SqlDateTime(leftDate), new SqlDateTime(rightDate)});
        }
        
        public static YoktoObject Get (int objectId, DateTime Day)
        {
            
            
            YoktoObject o = new YoktoObject();
            try
            {
                DataSet ds = GetObjectDataSet(objectId, Day);
                o.name = Database.EvalField(ds, "Name").ToString();
                o.tags = GetTagString(objectId);
                o.description = Database.EvalField(ds, "Description").ToString();
                o.location = Database.EvalField(ds, "Location").ToString();
                o.contactData = Database.EvalField(ds, "ContactData").ToString();
                o.culture = Database.EvalField(ds, "Culture").ToString();
                o.isService = (bool)Database.EvalField(ds, "IsService");
                o.supplierName = Database.EvalField(ds, "RepresentatorUName").ToString();
                o.googleLat = Convert.ToDouble(Database.EvalField(ds, "GoogleX"));
                o.googleLong = Convert.ToDouble(Database.EvalField(ds, "GoogleY"));

            }
            catch
            {
            }
            return o;
        }
        public YoktoObject()
        {
            
        }
        public YoktoObject(int objectId)
        {
            DateTime Day = DateTime.Now;
            try
            {
                DataSet ds = GetObjectDataSet(objectId, Day);
                name = Database.EvalField(ds, "Name").ToString();
                tags = GetTagString(objectId);
                description = Database.EvalField(ds, "Description").ToString();
                location = Database.EvalField(ds, "Location").ToString();
                contactData = Database.EvalField(ds, "ContactData").ToString();
                culture = Database.EvalField(ds, "Culture").ToString();
                isService = (bool)Database.EvalField(ds, "IsService");
                supplierName = Database.EvalField(ds, "RepresentatorUName").ToString();
                googleLat = Convert.ToDouble(Database.EvalField(ds, "GoogleX"));
                googleLong = Convert.ToDouble(Database.EvalField(ds, "GoogleY"));

            }
            catch
            {
            }
        }
        public static YoktoObject Get(int objectId)
        {
            DateTime Day = DateTime.Now;
            YoktoObject o = new YoktoObject();
            try
            {
                DataSet ds = GetObjectDataSet(objectId, Day);
                o.name = Database.EvalField(ds, "Name").ToString();
                o.tags = GetTagString(objectId);
                o.description = Database.EvalField(ds, "Description").ToString();
                o.location = Database.EvalField(ds, "Location").ToString();
                o.contactData = Database.EvalField(ds, "ContactData").ToString();
                o.culture = Database.EvalField(ds, "Culture").ToString();
                o.isService = (bool) Database.EvalField(ds, "IsService");
                o.supplierName = Database.EvalField(ds, "RepresentatorUName").ToString();
                o.googleLat = Convert.ToDouble(Database.EvalField(ds, "GoogleX"));
                o.googleLong = Convert.ToDouble(Database.EvalField(ds, "GoogleY"));
                o.originalImageHref = Database.EvalField(ds, "OriginalSizeImageHref").ToString();
                o.thumbImageHref = Database.EvalField(ds, "ThumbImageHref").ToString();
                o.smallImageHref = Database.EvalField(ds, "SmallSizeImageHref").ToString();


            }
            catch
            {
            }
            return o;
        }
        public static YoktoObject Get(DataSet ds, int row)
        {
            YoktoObject o = new YoktoObject();
            try
            {
                o.rating = Convert.ToInt32(Database.EvalField(ds, "Rating", row));
                o.id = Convert.ToInt32(Database.EvalField(ds, "Id", row));
                o.name = Database.EvalField(ds, "Name",row).ToString();
                o.tags = ""; //в целях повышения производительности и сокращения обращений к бд
                o.description = Database.EvalField(ds, "Description", row).ToString();
                o.location = Database.EvalField(ds, "Location", row).ToString();
                o.contactData = Database.EvalField(ds, "ContactData", row).ToString();
                o.culture = Database.EvalField(ds, "Culture", row).ToString();
                o.isService = (bool)Database.EvalField(ds, "IsService", row);
                o.supplierName = Database.EvalField(ds, "RepresentatorUName", row).ToString();
                o.googleLat = Convert.ToDouble(Database.EvalField(ds, "GoogleX",row));
                o.googleLong = Convert.ToDouble(Database.EvalField(ds, "GoogleY",row));

            }
            catch
            {
            }
            return o;
        }


        public static int Save(int objectId, string name, string description, string culture,
                               string contactData, double googleX, double googleY, string location,
                               bool isService,string userName, ImageHandler.ImageHrefs img)
        {
            return
                Convert.ToInt32(
                    Database.ExecuteScalar("SaveObject",
                                           new string[]
                                               {
                                                   "@ObjectId", "@Name", "@Description", "@Culture", "@ContactData",
                                                   "@GoogleX", "@GoogleY", "@Location", "@IsService", "@UserName",
                                                   "@ThumbImageHref", "@SmallSizeImageHref", "@OriginalSizeImageHref"
                                               },
                                           new object[]
                                               {
                                                   objectId, name, description, culture, contactData, googleX, googleY,
                                                   location, isService, userName, img.ThumbImageHref,
                                                   img.SmallSizeImageHref, img.OriginalSizeImageHref
                                               }));
        }

        public static List<DateSpan> GetTimeTable(int objectId)
        {
            List<DateSpan> l = new List<DateSpan>();
            DataSet ds = Database.ExecuteQuery("GetObjectCalendar", new string[] {"@ObjectId"}, new object[] {objectId});
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                l.Add(
                    new DateSpan((DateTime) ds.Tables[0].Rows[i]["BusyDateStart"],
                                 (DateTime) ds.Tables[0].Rows[i]["BusyDateEnd"]));
            }
            return l;
        }

        public static void Remove(int objectId)
        {
            Database.ExecuteNonQuery("RemoveObject", new string[] {"@ObjectId", "@UserName"},
                                     new object[] {objectId, Membership.GetUser().UserName});
        }

        public static bool IsFavourite(int objectId)
        {
            MembershipUser u = Membership.GetUser();
            if (u == null) return false;
            if (Roles.IsUserInRole(u.UserName, "User"))
            {
                return (bool) Database.ExecuteScalar("IsObjectFavourite", new string[] {"@UserName", "@ObjectId"},
                                                     new object[] {Membership.GetUser().UserName, objectId});
            }
            return false;
        }

        public static string GetTagString(int objectId)
        {
            DataSet ds = Database.ExecuteQuery("ListObjectTags", new string[] {"@ObjectId"}, new object[] {objectId});
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["Tag"].ToString().Trim()!=string.Empty) sb.Append(ds.Tables[0].Rows[i]["Tag"]).Append(", ");
            }
            return sb.ToString();
        }

        public static void SaveTagString(string tags, int objectId)
        {
            Database.ExecuteNonQuery("SaveObjectTagString", new string[] {"@TagString", "@ObjectId"},
                                     new object[] {tags, objectId});
        }

        public static void ResetCommentsCounter(int objectId)
        {
            Database.ExecuteNonQuery("ResetCommentsCounter", new string[] {"@ObjectId"},
                                     new object[] {objectId});
        }

        public static void SaveCalendarEntry(int objectId, DateTime? busyDateStart, DateTime? busyDateEnd,
                                             string description)
        {
            Database.ExecuteNonQuery("SaveCalendarEntry",
                                     new string[] {"@ObjectId", "@BusyDateStart", "@BusyDateEnd", "@Description"},
                                     new object[] {objectId, busyDateStart, busyDateEnd, description});
        }

        public static void SaveCalendarEntry(CalendarEntry c, int objectId)
        {
            SaveCalendarEntry(objectId,c.Start,c.End,c.Description);
        }

        public static CalendarEntry[] GetCalendarEntries(int objectId)
        {
            DataSet ds = Database.ExecuteQuery("GetObjectCalendar", new string[] {"@ObjectId"}, new object[] {objectId});
            CalendarEntry[] reslt = new CalendarEntry[ds.Tables[0].Rows.Count];
            for (int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                reslt[i] = new CalendarEntry(Convert.ToDateTime(Database.EvalField(ds, "BusyDateStart", i)), Convert.ToDateTime(Database.EvalField(ds, "BusyDateEnd", i)), Database.EvalField(ds, "Description", i).ToString(),Convert.ToInt32(Database.EvalField(ds,"EntryId",i)));
            }
            return reslt;
        }
        public static void RemoveCalendarEntry(int entryId)
        {
            Database.ExecuteNonQuery("RemoveCalendarEntry", new string[] {"@EntryId"}, new object[] {entryId});
        }

        public static bool Belongs(int objectId, string userName)
        {
            return
                (bool)
                Database.ExecuteScalar("IsObjectBelongsToUser", new string[] {"@UserName", "@ObjectId"},
                                       new object[] {userName, objectId}
                    );
        }
        /*public static void Save(YoktoObject o)
        {
            Save(o.Id, o.Name, o.Description, Convert.ToInt32(o.CategId), o.Culture, o.ContactData, o.GoogleLat,
                 o.GoogleLong, o.Location, null, o.IsService, Convert.ToInt32(o.ServiceName), o.ImageId, null);
        }*/
        public static List<YoktoCategorie> GetObjectCategories(int objectId,string lang)
        {
            DataSet ds =
                Database.ExecuteQuery("GetObjectCategories", new string[] {"@Id","@Locale"}, new object[] {objectId,lang});
            List<YoktoCategorie> reslt =
            new List<YoktoCategorie>();
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                reslt.Add(new YoktoCategorie(Convert.ToInt32(Database.EvalField(ds,"CategoryId",i)),Database.EvalField(ds,"Name",i).ToString(),Database.EvalField(ds,"Locale",i).ToString(),Convert.ToInt32(Database.EvalField(ds,"ParentId",i))));
            }
            return reslt;
        }
    }
    public class CalendarEntry : DateSpan
    {
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        private int id;
        private string description;
        public CalendarEntry()
        {
            
        }
        public CalendarEntry(DateTime startDate, DateTime endDate, string d, int id)
        {
            description = d;
            Start = startDate;
            End = endDate;
            Id = id;
        }
    }   
}