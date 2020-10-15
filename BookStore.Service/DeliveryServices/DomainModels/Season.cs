namespace BookStore.Service.DeliveryServices.DomainModels
{
    public class Season
    {
        public string Name { get; set; }
        public MonthEnum? From { get; set; }
        public MonthEnum? To { get; set; }
        public decimal Factor { get; set; }
    }

    public enum MonthEnum
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
}
