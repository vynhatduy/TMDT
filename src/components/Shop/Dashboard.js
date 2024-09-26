import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFilter } from '@fortawesome/free-solid-svg-icons';
import { Bar, Pie } from 'react-chartjs-2';
import { Chart, registerables } from 'chart.js'; // Import Chart.js và các thành phần
import './ShopDashboard.css';

// Đăng ký tất cả các thành phần cần thiết
Chart.register(...registerables);

const Dashboard = () => {
  const [dateRange, setDateRange] = useState('18/9/2024 ~ 26/9/2024');
  const [showDatePicker, setShowDatePicker] = useState(false);
  const [startDate, setStartDate] = useState('');
  const [endDate, setEndDate] = useState('');

  const handleDateInputClick = () => {
    setShowDatePicker(!showDatePicker);
  };

  const handleDateSubmit = () => {
    setDateRange(`${startDate} ~ ${endDate}`);
    setShowDatePicker(false);
  };

  // Dữ liệu mẫu cho biểu đồ
  const salesData = {
    labels: ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6', 'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'],
    datasets: [
      {
        label: 'Doanh thu',
        data: [1200, 1900, 3000, 500, 2500],
        backgroundColor: 'rgba(75, 192, 192, 0.6)',
        borderColor: 'rgba(75, 192, 192, 1)',
        borderWidth: 1,
      },
    ],
  };

  const categoryData = {
    labels: ['Sản phẩm A', 'Sản phẩm B', 'Sản phẩm C'],
    datasets: [
      {
        data: [300, 500, 200],
        backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56'],
      },
    ],
  };

  return (
    <div className="shop-dashboard">
      <div className="sales-overview">
        <h2>Tổng quan bán hàng</h2>
        <div className="date-filter">
          <input
            type="text"
            value={dateRange}
            onClick={handleDateInputClick}
            readOnly
            placeholder="Chọn thời gian..."
          />
          <button className="filter-btn">
            <FontAwesomeIcon icon={faFilter} /> Filter
          </button>
          {showDatePicker && (
            <div className="date-picker active">
              <input
                type="date"
                value={startDate}
                onChange={(e) => setStartDate(e.target.value)}
              />
              <input
                type="date"
                value={endDate}
                onChange={(e) => setEndDate(e.target.value)}
              />
              <button onClick={handleDateSubmit}>Xác nhận</button>
            </div>
          )}
        </div>
      </div>

      <div className="summary-cards">
        <div className="card">
          <h3>Tổng quan doanh thu</h3>
          <p>$1000</p>
          <p>Tăng 10% so với tháng trước</p>
        </div>
        <div className="card">
          <h3>Tổng quan đơn hàng</h3>
          <p>150 đơn</p>
          <p>Tăng 5% so với tháng trước</p>
        </div>
        <div className="card">
          <h3>Tổng quan mua hàng</h3>
          <p>Tăng 8% so với tháng trước</p>
        </div>
      </div>

      <div className="charts">
        <div className="left">
          <h3>Thống kê bán hàng</h3> {/* Tiêu đề cho biểu đồ cột */}
          <div className="bar-chart">
            <Bar data={salesData} options={{ responsive: true }} />
          </div>
        </div>
        <div className="right">
          <h3>Thống kê theo danh mục</h3> {/* Tiêu đề cho biểu đồ hình tròn */}
          <div className="pie-chart">
            <Pie data={categoryData} options={{ responsive: true }} />
          </div>
        </div>
      </div>

      <div className="tables">
        <div className="recent-orders">
          <h3>20 đơn hàng gần nhất</h3>
          <table>
            <thead>
              <tr>
                <th>ID Hóa đơn</th>
                <th>Trạng thái</th>
                <th>Ngày</th>
                <th>Tên người đặt</th>
                <th>Tổng tiền</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>#001</td>
                <td>Đã giao</td>
                <td>20/9/2024</td>
                <td>Nguyễn Văn A</td>
                <td>$100</td>
              </tr>
              {/* Các đơn hàng mẫu khác */}
            </tbody>
          </table>
        </div>
        <div className="best-selling-products">
          <h3>Sản phẩm bán chạy</h3>
          <table>
            <thead>
              <tr>
                <th>Hình ảnh</th>
                <th>Tên sản phẩm</th>
                <th>Số lượng đã bán</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td><img src="image_url_1" alt="Sản phẩm 1" /></td>
                <td>Sản phẩm 1</td>
                <td>50</td>
              </tr>
              {/* Các sản phẩm mẫu khác */}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
};

export default Dashboard;
