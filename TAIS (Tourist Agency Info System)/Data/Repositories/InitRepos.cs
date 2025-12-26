using System;
using System.Collections.Generic;
using System.Text;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class InitRepos
    {
        public AircraftTypeRepository aircraftRep;
        public CarrierRepository carrierRep;
        public ChildRepository childRep;
        public CityRepository cityRep;
        public ClientRepository clientRep;
        public CountryRepository countryRep;
        public EmployeeRepository employeeRep;
        public FlightRepository flightRep;
        public HotelRepository hotelRep;
        public HREventRepository hrEventRep;
        public OrderRepository orderRep;
        public PositionRepository positionRep;
        public RoutePointRepository routePointRep;
        public RouteRepository routeRep;
        public StreetRepository streetRep;
        public TicketRepository tickerRep;
        public TripRepository tripRep;
        public VoyageRepository voyageRep;

        public InitRepos()
        {
            aircraftRep = new AircraftTypeRepository();
            carrierRep = new CarrierRepository();
            countryRep = new CountryRepository();
            cityRep = new CityRepository(countryRep);
            hotelRep = new HotelRepository(cityRep);
            streetRep = new StreetRepository();
            positionRep = new PositionRepository();
            employeeRep = new EmployeeRepository(streetRep);
            hrEventRep = new HREventRepository(streetRep, positionRep, employeeRep);
            voyageRep = new VoyageRepository(carrierRep, aircraftRep);
            flightRep = new FlightRepository(voyageRep);
            routeRep = new RouteRepository(countryRep, employeeRep);
            routePointRep = new RoutePointRepository(routeRep, cityRep, hotelRep, employeeRep);
            clientRep = new ClientRepository();
            childRep = new ChildRepository(clientRep);
            tickerRep = new TicketRepository(clientRep, flightRep);
            tripRep = new TripRepository(routeRep, employeeRep, flightRep);
            orderRep = new OrderRepository(clientRep, tripRep);
        }
    }
}
