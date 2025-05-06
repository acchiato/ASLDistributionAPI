namespace ASLDistributionAPI.Models
{
    public class JobModel
    {
        public long ID { get; set; }
        public Result Results { get; set; }

        public class Result
        {
            public bool Success { get; set; }
            public List<Error> Errors { get; set; }

            public class Error
            {
                public string Field { get; set; }
                public string Message { get; set; }
            }
        }
    }
}
