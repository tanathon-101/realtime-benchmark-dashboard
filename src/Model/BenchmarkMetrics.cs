namespace src.Model
{
    public class BenchmarkMetrics
    {
        public long MemoryUsageMB { get; set; }
        public int ThreadCount { get; set; }
        public int Gen0 { get; set; }
        public int Gen1 { get; set; }
        public int Gen2 { get; set; }
    }

}