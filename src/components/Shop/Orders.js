import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrash, faEye } from '@fortawesome/free-solid-svg-icons';
import { useNavigate } from 'react-router-dom';
import './Orders.css'; // Import CSS file

const Orders = () => {
  const navigate = useNavigate(); // Khởi tạo useNavigate
  const [invoices, setInvoices] = useState([
    { id: 1, date: '2024-09-01', buyer: 'Nguyễn Văn A', status: 'Chưa thanh toán', paymentMethod: 'Chuyển khoản (****1234)', total: 500000 },
    { id: 2, date: '2024-09-05', buyer: 'Trần Thị B', status: 'Đã thanh toán', paymentMethod: 'COD', total: 300000 },
    { id: 3, date: '2024-09-10', buyer: 'Lê Văn C', status: 'Chưa thanh toán', paymentMethod: 'Chuyển khoản (****5678)', total: 450000 },
    // Thêm dữ liệu mẫu khác nếu cần
  ]);
  
  const [selectedInvoices, setSelectedInvoices] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');

  const handleSelectAll = (e) => {
    const checked = e.target.checked;
    setSelectedInvoices(checked ? invoices.map(invoice => invoice.id) : []);
  };

  const handleSelectInvoice = (id) => {
    setSelectedInvoices(prev =>
      prev.includes(id) ? prev.filter(i => i !== id) : [...prev, id]
    );
  };

  const handleDelete = () => {
    setInvoices(prev => prev.filter(invoice => !selectedInvoices.includes(invoice.id)));
    setSelectedInvoices([]);
  };

  const handleSearch = (e) => {
    setSearchTerm(e.target.value);
  };

  const filteredInvoices = invoices.filter(invoice =>
    invoice.buyer.toLowerCase().includes(searchTerm.toLowerCase()) ||
    invoice.id.toString().includes(searchTerm) ||
    invoice.date.includes(searchTerm)
  );

  const handleViewDetail = (id) => {
    navigate(`/shop/order-detail/${id}`); // Điều hướng đến trang chi tiết hóa đơn
  };

  return (
    <div className="orders">
      <h1>Hóa đơn</h1>
      {/* Khối thứ nhất */}
      <div className="header">
        <h2>Danh sách hóa đơn</h2>
        <div className="actions">
          {selectedInvoices.length > 0 && (
            <>
              <button onClick={handleDelete}>Xóa</button>
              <button>Xác nhận giao hàng</button>
            </>
          )}
          <input
            type="text"
            placeholder="Tìm kiếm hóa đơn..."
            value={searchTerm}
            onChange={handleSearch}
          />
        </div>
      </div>

      {/* Khối thứ hai: Bảng hóa đơn */}
      <div className="invoice-table">
        <table>
          <thead>
            <tr>
              <th>
                <input
                  type="checkbox"
                  checked={selectedInvoices.length === filteredInvoices.length && filteredInvoices.length > 0}
                  onChange={handleSelectAll}
                />
              </th>
              <th onClick={() => setInvoices([...invoices].sort((a, b) => a.id - b.id))}>ID</th>
              <th onClick={() => setInvoices([...invoices].sort((a, b) => new Date(a.date) - new Date(b.date)))}>Ngày tạo</th>
              <th onClick={() => setInvoices([...invoices].sort((a, b) => a.buyer.localeCompare(b.buyer)))}>Tên người mua</th>
              <th onClick={() => setInvoices([...invoices].sort((a, b) => a.status.localeCompare(b.status)))}>Trạng thái</th>
              <th onClick={() => setInvoices([...invoices].sort((a, b) => a.paymentMethod.localeCompare(b.paymentMethod)))}>Phương thức thanh toán</th>
              <th onClick={() => setInvoices([...invoices].sort((a, b) => a.total - b.total))}>Tổng tiền</th>
              <th>Hành động</th>
            </tr>
          </thead>
          <tbody>
            {filteredInvoices.map(invoice => (
              <tr key={invoice.id}>
                <td>
                  <input
                    type="checkbox"
                    checked={selectedInvoices.includes(invoice.id)}
                    onChange={() => handleSelectInvoice(invoice.id)}
                  />
                </td>
                <td>{invoice.id}</td>
                <td>{invoice.date}</td>
                <td>{invoice.buyer}</td>
                <td style={{ color: invoice.status === 'Chưa thanh toán' ? 'red' : 'green' }}>{invoice.status}</td>
                <td>{invoice.paymentMethod}</td>
                <td>{invoice.total.toLocaleString()} VND</td>
                <td>
                  <FontAwesomeIcon 
                    icon={faEye} 
                    className="view-icon" 
                    onClick={() => handleViewDetail(invoice.id)} // Thêm hàm điều hướng
                    style={{ cursor: 'pointer', marginRight: '10px' }}
                  />
                  <FontAwesomeIcon icon={faTrash} className="delete-icon" onClick={() => handleDelete(invoice.id)} />
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default Orders;
