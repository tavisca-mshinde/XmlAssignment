using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NLog;
using log4net;
using log4net.Config;

namespace HotelMgmtSystem
{
    class HotelConsole
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(HotelConsole));
        //private static Logger logger = LogManager.GetCurrentClassLogger();
        
        static long hotelId = 0;
        static long custId = 0, bookingId = 0, roomId=0;
        static LINQtoSQLDataContext linqtosqlDataContext = new LINQtoSQLDataContext();
        //static Logging logdata = new Logging();
        static void Main(string[] args)
        {
            //XmlConfigurator.Configure("log4net.xml");
            XmlConfigurator.Configure();
            while (true)
            {try
                {
                    Console.WriteLine("Enter Your Role");
                    Console.WriteLine("1 . Customer");
                    Console.WriteLine("2 . Agent");
                    string yourRole = (Console.ReadLine());
                    switch (yourRole)
                    {
                        case "1":
                            CuctomerRole();
                            break;
                        case "2":
                            AgentRole();
                            break;
                        default:
                            Environment.Exit(0);
                            break;

                    }
                }catch(Exception e) { logger.Error(e.Message); }
            }
            
        }
        public static void CuctomerRole()
        {

            Console.WriteLine("Choose");
            Console.WriteLine("1. Check in");
            Console.WriteLine("2. Check Out");
            string choice = Console.ReadLine();
            //SelectRooms selectRooms = new SelectRooms();
            //SelectBooking selectBooking = new SelectBooking();
            switch (choice)
            {
                case "1":
                    hotelId = SelectByCity();
                    var rooms = from room in linqtosqlDataContext.Rooms where room.HotelId == hotelId select room;
                   // ArrayList rooms = selectRooms.GetRoomByHotelId(hotelId);
                    Console.WriteLine("Rooms status");
                    Console.WriteLine(" RoomId  HotelId  RoomType  AvailableRooms  TotalRooms");
                    foreach (Room room in rooms)
                    {
                        Console.WriteLine(" {0}   {1}   {2}   {3}   {4}", room.RoomId, room.HotelId, room.RoomType, room.AvailableRooms, room.TotalRooms);
                    }

                    Console.WriteLine("Enter Room Id");
                    roomId = Convert.ToInt32(Console.ReadLine());
                    if (roomId % 2 == 1)
                        throw new Exception("Odd no entered");

                    Console.WriteLine("Enter your Details bellow");
                    Console.WriteLine("Enter CustomerName");
                    string CustomerName = Console.ReadLine();
                    //Console.WriteLine("Enter LastName");
                    //string lastName = Console.ReadLine();
                    Console.WriteLine("Enter EmailId");
                    string emailId = Console.ReadLine();
                    Console.WriteLine("Enter Phone Numer");
                    string phoneNumber = Console.ReadLine();
                    // logdata.logmethod(DateTime.Now+"  :  customer "+ CustomerName + " checked in for RoomId "+ roomId + " in Hotel Id "+ hotelId);
                    logger.Info("new customer is added"+ CustomerName +"EmailId"+ emailId);
                    //logger.Trace("New Customer with name {0} for hotelId {1} for room type Id {2}",CustomerName,hotelId,roomId);
                    //SelectCustomer selectCustomer = new SelectCustomer();
                    //custId = selectCustomer.InsertCustomerData(firstName, lastName, emailId, phoneNumber);
                    Int64 custId =(Int64) linqtosqlDataContext.spInsertCustomer(CustomerName, emailId, phoneNumber).SingleOrDefault().Column1.Value;
                    //Customer customer = new Customer
                    //{

                    //};
                    //linqtosqlDataContext.Customers.
                    Console.WriteLine("Adding Booking Details");
                    Int64 bookingId =(Int64)linqtosqlDataContext.spInsertBookingDetails(custId, hotelId, roomId).SingleOrDefault().Column1.Value;
                    //long bookingId = selectBooking.InsertBookingData(custId, hotelId);
                  //  logdata.logmethod(DateTime.Now + "customers booking deatails are added");
                    Console.WriteLine("Booking Details are Added Id is {0}", bookingId);
                    logger.Info("New customer booked in with Booking Id"+ bookingId);
                    //logger.Trace("New customer booked in with Booking Id {0}", bookingId);
                    linqtosqlDataContext.spUpdateRoomsdata(roomId);
                    //selectRooms.UpdateRoomsData(roomId);
                    break;

                case "2":
                    hotelId = SelectByCity();
                    //ArrayList roomtocheckout = selectRooms.GetRoomByHotelId(hotelId);
                    //foreach (Room room in roomtocheckout)
                    //{
                    //    Console.WriteLine(" {0}   {1} ", room.RoomId, room.HotelId);
                    //}
                    var bookingDetails = from bookingDetail in linqtosqlDataContext.BookingDetails where bookingDetail.HotelId == hotelId select bookingDetail;
                    //var bookingDetails = linqtosqlDataContext.spSelectBookingDetailByHotelId(hotelId);
                    foreach (BookingDetail bookingDetail in bookingDetails)
                    {
                        Console.WriteLine(" {0}   {1}   {2}   {3}   {4}  {5}", bookingDetail.BookingId, bookingDetail.CustomerId, bookingDetail.HotelId, bookingDetail.RoomId,bookingDetail.CheckInDate,bookingDetail.CheckOutDate);
                    }
                    Console.WriteLine("Enter your Booking Id for check out");
                    long bookingId1 = Convert.ToInt64(Console.ReadLine());
                    //selectBooking.UpdateBookingData(bookingId1);
                    linqtosqlDataContext.spUpdateBookingDetails(bookingId1);
                    BookingDetail bd = linqtosqlDataContext.BookingDetails.SingleOrDefault(x => x.BookingId==bookingId1);
                    //long rid = linqtosqlDataContext.
                    logger.Info("customer checked out");
                    long rid = (Int64)bd.RoomId;
                    Room rmForUpdate = linqtosqlDataContext.Rooms.SingleOrDefault(x => x.RoomId == rid);
                    rmForUpdate.AvailableRooms = rmForUpdate.AvailableRooms + 1;
                   // linqtosqlDataContext.SubmitChanges();
                    Console.WriteLine("CheckedOut Successfully");
                    break;
            }




        }

        private static int SelectByCity()
        {
            Console.WriteLine("Enter Your City");
            string city = Console.ReadLine();
            //SelectHotel selectHotel = new SelectHotel();
            //ArrayList hotels = selectHotel.GetHotelsByCity(city);
            var hotels = from hotel in linqtosqlDataContext.Hotels where hotel.City == city select hotel; 
            Console.WriteLine("hotels in {0}", city);
            logger.Info("city searched by user" + city);
            //logger.Trace("city searched by user {0}", city);
            foreach (Hotel hotel in hotels)
            {
                Console.WriteLine(hotel.HotelId + " . " + hotel.HotelName +" . "+ hotel.PhoneNumber);
            }
            //int hotelId=
            return Convert.ToInt32(Console.ReadLine());
        }

        public static void AgentRole()
        {
            string detailsByAgent;

            Console.WriteLine("1.To Enter Hotel Detail");
            Console.WriteLine("2.To Enter Room Detail");
            detailsByAgent = (Console.ReadLine());
            switch (detailsByAgent)
            {
                case "1":
                    //SelectByCity();
                    Console.WriteLine("Enter Name of Hotel");
                    string hotelName = Console.ReadLine();
                    Console.WriteLine("Enter Phone Numer");
                    string phoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter City");
                    string city = Console.ReadLine();
                    linqtosqlDataContext.spInsertHotels(hotelName, phoneNumber, city);
                    logger.Info("data entered by agent : name of hotel " + hotelName + " and city " + city);
                    //logger.Trace("data entered by agent : name of hotel {0} and city {1}",hotelName,city);
                  //  logdata.logmethod(DateTime.Now+"hotel added "+hotelName + " with phone number"+phoneNumber +"and city "+city);
                    //SelectHotel selectHotel = new SelectHotel();
                    //HotelDBOps hotelDBOps = new HotelDBOps();
                    //hotelDBOps.InsertHotels(hotelName, phoneNumber, city);
                    //selectHotel.InsertHotelData(hotelName, phoneNumber, city);
                    break;
                case "2":
                    int hotelId = SelectByCity();


                    //Console.WriteLine("Enter Id of Hotel");
                    //int hotelId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Room Type");
                    string roomType = Console.ReadLine();
                    Console.WriteLine("Enter Total Rooms");
                    int totalRooms = Convert.ToInt32(Console.ReadLine());
                    //SelectRooms selectRooms = new SelectRooms();
                    //RoomDBOps roomDBOps = new RoomDBOps();
                    //roomDBOps.InsertRooms(hotelId, roomType, totalRooms, totalRooms);
                    //selectRooms.InsertRoomsData(hotelId, roomType, totalRooms, totalRooms);
                    linqtosqlDataContext.spInsertRoom(hotelId, roomType, totalRooms, totalRooms);
                    //AgentRole();
                    logger.Info("rooms entered by agent for hotelId " + hotelId + " and type of room " + roomType);
                    //logger.Trace("rooms entered by agent for hotelId {0} and type of room {1}",hotelId,roomType);
                    //logdata.logmethod(DateTime.Now + "rooms added by agent for hotel Id" + hotelId);
                    break;
                default:
                    break;

            }

        }
    }
}
