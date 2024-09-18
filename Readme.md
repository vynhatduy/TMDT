thực hiện chạy file database.sql trong ssms và chạy câu lệnh dưới 

dotnet ef dbcontext scaffold "Data Source=VYNHATDUY;Initial Catalog=TMDT;User ID=sa; Password=sa;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models
lưu ý mở quyền truy cập tài khoản sa trong ssms và đổi tên server link sau:https://qthang.net/huong-dan-bat-tai-khoan-sa-trong-sql-server