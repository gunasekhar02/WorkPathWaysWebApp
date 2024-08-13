namespace WorkPathways.WorkPathways.Models
{
    public class ResponseStructure<T>
    {
            public bool Success { get; set; }
            public T? Data { get; set; }
            public string? ErrorMessage { get; set; }
        
    }
}
