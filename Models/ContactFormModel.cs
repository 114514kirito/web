using System.ComponentModel.DataAnnotations;

namespace sujiayang.Models;

public class ContactFormModel
{
    [Required(ErrorMessage = "请输入您的姓名")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "请输入您的邮箱")]
    [EmailAddress(ErrorMessage = "请输入有效的邮箱地址")]
    [StringLength(200)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "请输入留言内容")]
    [StringLength(2000)]
    public string Message { get; set; } = string.Empty;
}
