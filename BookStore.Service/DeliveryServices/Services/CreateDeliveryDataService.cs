using BookStore.Service.DeliveryServices.DomainModels;
using System;
using System.Collections.Generic;

namespace BookStore.Service.DeliveryServices.Services
{
    public interface ICreateDeliveryDataService
    {
        IList<DeliveryService> Create();
    }

    public class CreateDeliveryDataService : ICreateDeliveryDataService
    {
        public IList<DeliveryService> Create()
        {
            return new List<DeliveryService>
                {
                    new DeliveryService
                    {
                        Id = (int)DeliveryServiceEnum.Motorbike,
                        Name = "Motorbike",
                        BaseCost = 5,
                        Seasons = new List<Season>
                        {
                            new Season {Name="June to Aug", From = MonthEnum.June, To = MonthEnum.August, Factor = 0.5m},
                            new Season {Name="Sep", From = MonthEnum.September, To = MonthEnum.September, Factor = 1.5m},
                            new Season {Name="Other months", From = null, To = null, Factor = 1m}
                        },
                        DeliveryInfo = new MotorbikeDeliveryInfo
                        {
                            DriverName = "Kelly",
                            DeliveryDate = new DateTime(2020,10,15),
                            DeliveryInfoType = DeliveryInfoTypeEnum.Motorbike,
                            Id = 1,
                            PhoneNumber = "+44123456789"
                        }
                    },
                    new DeliveryService
                    {
                        Id = (int)DeliveryServiceEnum.Train,
                        Name = "Train",
                        BaseCost = 10,
                        Seasons = new List<Season>
                        {
                            new Season {Name="June to Aug", From = MonthEnum.June, To = MonthEnum.August, Factor = 0.8m},
                            new Season {Name="Sep", From = MonthEnum.September, To = MonthEnum.September, Factor = 1.8m},
                            new Season {Name="Other months", From = null, To = null, Factor = 1m}
                        },
                        DeliveryInfo = new TrainDeliveryInfo
                        {
                            TrainNo = "T_DN_01",
                            DateOfArrival = new DateTime(2020,10,14),
                            DeliveryInfoType = DeliveryInfoTypeEnum.Train,
                            Id = 2,
                            StationOfArrival = "Sta_DN_01"
                        }
                    },
                    new DeliveryService
                    {
                        Id = (int)DeliveryServiceEnum.Aircraft,
                        Name = "Aircraft",
                        BaseCost = 20,
                        Seasons = new List<Season>
                        {
                            new Season {Name="June to Aug", From = MonthEnum.June, To = MonthEnum.August, Factor = 0.8m},
                            new Season {Name="Sep", From = MonthEnum.September, To = MonthEnum.September, Factor = 2m},
                            new Season {Name="Other months", From = null, To = null, Factor = 1m}
                        },
                        DeliveryInfo = new AircraftDeliveryInfo
                        {
                            FlightNo = "A_DN_01",
                            DateOfArrival = new DateTime(2020,10,16),
                            DeliveryInfoType = DeliveryInfoTypeEnum.Aircraft,
                            Id = 3,
                            GateOfArrival = "Air_DN_01"
                        }
                    }
                };
        }
    }
}
