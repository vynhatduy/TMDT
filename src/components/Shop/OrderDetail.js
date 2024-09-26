import React from 'react';
import './OrderDetail.css'; // Đảm bảo bạn đã tạo file CSS này

const OrderDetail = () => {
  const order = {
    id: '123456',
    status: 'Chưa thanh toán',
    completionStatus: 'Chưa hoàn thành',
    createdAt: '2024-09-26 10:00',
    products: [
      {
        id: 1,
        name: 'Sản phẩm A',
        type: 'Điện thoại',
        description: 'Điện thoại thông minh với nhiều tính năng.',
        price: 5000000,
        quantity: 1,
        imageUrl: 'path/to/imageA.jpg',
      },
      {
        id: 2,
        name: 'Sản phẩm B',
        type: 'Phụ kiện',
        description: 'Tai nghe không dây.',
        price: 1000000,
        quantity: 2,
        imageUrl: 'path/to/imageB.jpg',
      },
    ],
    shippingCompany: {
      name: 'Giao Hàng Nhanh',
      estimatedTime: '2-3 ngày',
      shippingFee: 30000,
    },
    buyer: {
      name: 'Nguyễn Văn A',
      previousOrders: 5,
      contact: {
        email: 'buyer@example.com',
        phone: '0123456789',
      },
      shopAddress: '123 Đường ABC, Quận 1, TP. HCM',
      deliveryAddress: '456 Đường DEF, Quận 2, TP. HCM',
    },
  };

  const totalPrice = order.products.reduce((total, product) => total + product.price * product.quantity, 0);
  const tax = totalPrice * 0.1; // Giả định thuế là 10%
  const totalOrderValue = totalPrice + tax + order.shippingCompany.shippingFee;

  return (
    <div className="order-detail-layout">
      <div className="order-detail-left">
        <div className="order-info">
          <h2>Hóa đơn #{order.id}</h2>
          <p>Trạng thái đơn hàng: {order.status}</p>
          <p>Trạng thái hoàn thành: {order.completionStatus}</p>
          <p>Ngày tạo: {order.createdAt}</p>
        </div>

        <div className="product-list">
          <h3>Danh sách sản phẩm</h3>
          <table>
            <thead>
              <tr>
                <th>Tên sản phẩm</th>
                <th>Đơn giá</th>
                <th>Số lượng</th>
                <th>Tổng tiền</th>
              </tr>
            </thead>
            <tbody>
              {order.products.map((product) => (
                <tr key={product.id}>
                  <td>
                    <img src={product.imageUrl} alt={product.name} />
                    <div>
                      <h4>{product.name}</h4>
                      <p>Loại: {product.type}</p>
                      <p>{product.description}</p>
                    </div>
                  </td>
                  <td>{product.price.toLocaleString()} VNĐ</td>
                  <td>{product.quantity}</td>
                  <td>{(product.price * product.quantity).toLocaleString()} VNĐ</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>

        <div className="shipping-info">
          <h3>Thông tin giao hàng</h3>
          {order.status === 'Đã xác nhận giao hàng' ? (
            <p>Chọn đơn vị vận chuyển:</p>
          ) : null}
          <div>
            <h4>{order.shippingCompany.name}</h4>
            <p>Thời gian giao ước tính: {order.shippingCompany.estimatedTime}</p>
            <p>Phí giao hàng: {order.shippingCompany.shippingFee.toLocaleString()} VNĐ</p>
          </div>
        </div>

        <div className="total-value">
          <h3>Tổng giá trị đơn hàng</h3>
          <p>Thành tiền: {totalPrice.toLocaleString()} VNĐ</p>
          <p>Phí giao hàng: {order.shippingCompany.shippingFee.toLocaleString()} VNĐ</p>
          <p>Thuế: {tax.toLocaleString()} VNĐ</p>
          <hr />
          <h4>Tổng giá trị đơn hàng: {totalOrderValue.toLocaleString()} VNĐ</h4>
        </div>
      </div>

      <div className="order-detail-right">
        <div className="buyer-info">
          <h3>Thông tin người mua</h3>
          <p>Tên: {order.buyer.name}</p>
          <p>Số lượng đơn hàng đã mua trước đây: {order.buyer.previousOrders}</p>
        </div>

        <div className="contact-info">
          <h3>Thông tin liên lạc</h3>
          <p>Email: {order.buyer.contact.email}</p>
          <p>Điện thoại: {order.buyer.contact.phone}</p>
        </div>

        <div className="shop-address">
          <h3>Địa chỉ shop</h3>
          <p>{order.buyer.shopAddress}</p>
        </div>

        <div className="delivery-address">
          <h3>Địa chỉ giao hàng</h3>
          <p>{order.buyer.deliveryAddress}</p>
        </div>
      </div>
    </div>
  );
};

export default OrderDetail;
