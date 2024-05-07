using System.Text;

namespace GeniuseeTestTask.Models.Rainfall;

public class ErrorResponse
{
    public string Message { get; set; }
    public List<ErrorDetail> Detail { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new(Message);

        if (Detail.Count is not 0) Detail.ForEach(detail => sb.AppendLine($"{detail.PropertyName} - {detail.Message}"));

        return sb.ToString();
    }
}