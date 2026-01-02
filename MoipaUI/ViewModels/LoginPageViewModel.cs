using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using MoipaUI.Models;
using MoipaUI.Views;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MoipaUI.ViewModels;

public partial class LoginPageViewModel : ObservableObject
{
    [ObservableProperty] private string? _userName;

    [ObservableProperty] private bool _loginStatus;

    [ObservableProperty] private string? _passWord;
    [ObservableProperty] private string? _keyStr;
    [ObservableProperty] private ImageSource? _imgStr;

    public LoginPageViewModel()
    {
        CaptchaGet();
    }

    [RelayCommand]
    private async Task Login()
    {
        // if (UserName is null || PassWord is null)
        // {
        //     await Shell.Current.DisplayAlert("错误信息", "账号或者密码不能为空！", "OK");
        // }
        // else if (UserName == "admin" && PassWord =="admin")//todo 验证登录逻辑
        // {
        //     await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
        // }
        // else
        // {
        //     await Shell.Current.DisplayAlert("错误信息", "账号或者密码错误！", "OK");
        //     UserName = null;
        //     PassWord = null;
        //
        // }
        await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
    }

    [RelayCommand]
    private async Task CaptchaGet()
    {
        try
        {
            var url = "http://192.168.1.117:8808/api/v1/pub/captcha/get";

            Debug.WriteLine($"=== 开始加载验证码 ===");

            // 方法1：使用 System.Text.Json
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // 发送请求
            using var client = new HttpClient();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"原始JSON长度: {jsonString.Length}");

                // 解析JSON
                var apiResponse = JsonSerializer.Deserialize<CaptchaApiResponse<Captcha>>(jsonString, options);

                if (apiResponse != null && apiResponse.Code == 0)
                {
                    Debug.WriteLine($"响应码: {apiResponse.Code}");
                    Debug.WriteLine($"消息: {apiResponse.Message}");
                    Debug.WriteLine($"Key: {apiResponse.Data.Key}");
                    Debug.WriteLine($"Base64图片长度: {apiResponse.Data.ImageBase64?.Length ?? 0}");

                    // 检查是否是完整的base64
                    if (!string.IsNullOrEmpty(apiResponse.Data.ImageBase64))
                    {
                        // base64字符串通常以 "data:image/png;base64," 开头
                        string base64Data;

                        if (apiResponse.Data.ImageBase64.Contains(","))
                        {
                            base64Data = apiResponse.Data.ImageBase64.Split(',')[1];
                            Debug.WriteLine("检测到data URI前缀，已去除");
                        }
                        else
                        {
                            base64Data = apiResponse.Data.ImageBase64;
                        }

                        // 转换为ImageSource并显示
                        await SetImageFromBase64(base64Data);
                        KeyStr = apiResponse.Data.Key;
                    }
                    else
                    {
                        Debug.WriteLine("Base64图片数据为空");
                        await Shell.Current.DisplayAlert("错误", "验证码数据为空", "确定");
                    }
                }
                else
                {
                    Debug.WriteLine($"API响应错误: {apiResponse?.Code} - {apiResponse?.Message}");
                    await Shell.Current.DisplayAlert("错误", $"API响应错误: {apiResponse?.Message}", "确定");
                }
            }
            else
            {
                Debug.WriteLine($"HTTP错误: {response.StatusCode}");
                await Shell.Current.DisplayAlert("错误", $"HTTP错误: {response.StatusCode}", "确定");
            }
        }
        catch (JsonException jsonEx)
        {
            Debug.WriteLine($"JSON解析异常: {jsonEx.Message}");
            await Shell.Current.DisplayAlert("错误", $"JSON解析失败: {jsonEx.Message}", "确定");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"异常: {ex.Message}");
            Debug.WriteLine($"堆栈: {ex.StackTrace}");
            await Shell.Current.DisplayAlert("错误", $"加载失败: {ex.Message}", "确定");
        }
    }

    // 将base64转换为ImageSource并设置到ImageButton
    private async Task SetImageFromBase64(string base64String)
    {
        try
        {
            if (string.IsNullOrEmpty(base64String))
            {
                Debug.WriteLine("Base64字符串为空");
                return;
            }

            Debug.WriteLine($"Base64字符串长度: {base64String.Length}");

            // 解码base64
            var imageBytes = Convert.FromBase64String(base64String);
            Debug.WriteLine($"解码后字节长度: {imageBytes.Length}");

            // 创建ImageSource
           ImgStr = ImageSource.FromStream(() => new MemoryStream(imageBytes));

            
        }
        catch (FormatException formatEx)
        {
            Debug.WriteLine($"Base64格式错误: {formatEx.Message}");
            await Shell.Current.DisplayAlert("错误", "图片格式错误", "确定");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"设置图片异常: {ex.Message}");
            await Shell.Current.DisplayAlert("错误", $"设置图片失败: {ex.Message}", "确定");
        }
    }
}