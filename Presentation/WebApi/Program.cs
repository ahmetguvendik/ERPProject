using Persistance; 
using Application;
using Application.Validations.AppUserValidation;
using Application.Validations.LeaveRequestValidation;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Gerekli servisleri ekle (mevcut kayıtlarınız)
builder.Services.AddControllers();
builder.Services.AddHttpClient(); // IHttpClientFactory için
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateLeaveRequestValidation>());
// Diğer katmanlardaki servis kayıtları (Eğer bu metodlar gerçekten varsa ve servisleri doğru ekliyorsa)
builder.Services.AddPersistanceService();
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials() // SignalR için MUTLAKA OLMALI
                .SetIsOriginAllowed(origin => true); // Development için '*' gibi düşünebilirsiniz, ancak güvenlik için spesifik origin belirtmek daha iyidir.
        });
});

var app = builder.Build();

// Swagger UI sadece development ortamında aktif olur
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");


app.UseHttpsRedirection(); 

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



app.Run(); // Uygulamayı başlat