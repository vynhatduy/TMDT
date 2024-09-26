import React, { useState, useRef } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFilter, faPen, faTrash } from '@fortawesome/free-solid-svg-icons';
import { Link } from 'react-router-dom'; // Import Link from react-router-dom
import './ProductManagement.css'; // Ensure you import the CSS file
import { useNavigate } from 'react-router-dom';

const ManageProducts = () => {
  const navigate = useNavigate();
  const [filterVisible, setFilterVisible] = useState(false);
  const [products, setProducts] = useState([
    {
      id: 1,
      name: 'Điện thoại A',
      category: 'Điện thoại',
      quantity: 50,
      status: 'Còn hàng',
      sold: 200,
      price: 200,
      imageUrl: 'https://via.placeholder.com/50',
    },
    {
      id: 2,
      name: 'Máy tính B',
      category: 'Máy tính',
      quantity: 30,
      status: 'Hết hàng',
      sold: 150,
      price: 1000,
      imageUrl: 'https://via.placeholder.com/50',
    },
    {
      id: 3,
      name: 'Phụ kiện C',
      category: 'Phụ kiện',
      quantity: 100,
      status: 'Còn hàng',
      sold: 50,
      price: 50,
      imageUrl: 'https://via.placeholder.com/50',
    },
  ]);
  const [sortOrder, setSortOrder] = useState(null);
  const filterRef = useRef(null);

  const toggleFilter = () => {
    setFilterVisible(!filterVisible);
  };

  const handleClickOutside = (e) => {
    if (filterRef.current && !filterRef.current.contains(e.target)) {
      setFilterVisible(false);
    }
  };

  const handleSort = (key) => {
    // Sorting logic here
    if (sortOrder === key) {
      // Toggle between ascending and descending
      setProducts([...products].reverse());
      setSortOrder(null);
    } else {
      // Sort in ascending order
      const sortedProducts = [...products].sort((a, b) => a[key] > b[key] ? 1 : -1);
      setProducts(sortedProducts);
      setSortOrder(key);
    }
  };

  const handleFilter = () => {
    // Load filtered products logic here
    setFilterVisible(false);
  };

  return (
    <div className="product-management">
      {/* First Block */}
      <div className="header">
        <h2>Trang sản phẩm</h2>
        <div className="search-filter">
          <input type="text" placeholder="Tìm kiếm sản phẩm..." />
          <button className="filter-btn" onClick={toggleFilter}>
            <FontAwesomeIcon icon={faFilter} /> Lọc
          </button>
          <button onClick={() => navigate('/shop/add-product')}>Thêm sản phẩm mới</button>
        </div>
      </div>

      {/* Filter Div */}
      {filterVisible && (
        <div className="filter-overlay" onClick={handleClickOutside}>
          <div className="filter-dropdown" ref={filterRef}>
            <h3>Chọn danh mục và trạng thái</h3>
            {/* Checkbox list for categories */}
            <div>
              <label>
                <input type="checkbox" /> Danh mục 1
              </label>
              <label>
                <input type="checkbox" /> Danh mục 2
              </label>
              {/* Add more categories as needed */}
            </div>
            <div>
              <label>
                <input type="radio" name="status" /> Còn hàng
              </label>
              <label>
                <input type="radio" name="status" /> Hết hàng
              </label>
              <label>
                <input type="radio" name="status" /> Tất cả
              </label>
              {/* Add more statuses as needed */}
            </div>
            <div className="filter-buttons">
              <button onClick={handleFilter}>Truy vấn</button>
              <button onClick={() => setFilterVisible(false)}>Hủy</button>
            </div>
          </div>
        </div>
      )}

      {/* Second Block: Product Table */}
      <div className="product-table">
        <table>
          <thead>
            <tr>
              <th onClick={() => handleSort('name')}>Tên</th>
              <th onClick={() => handleSort('category')}>Danh mục</th>
              <th onClick={() => handleSort('quantity')}>Số lượng</th>
              <th onClick={() => handleSort('status')}>Trạng thái</th>
              <th onClick={() => handleSort('sold')}>Đã bán</th>
              <th onClick={() => handleSort('price')}>Giá</th>
              <th>Hành động</th>
            </tr>
          </thead>
          <tbody>
            {products.map((product, index) => (
              <tr key={index}>
                <td>
                  <img src={product.imageUrl} alt={product.name} /> {product.name}
                </td>
                <td>{product.category}</td>
                <td>{product.quantity}</td>
                <td>{product.status}</td>
                <td>{product.sold}</td>
                <td>{product.price}</td>
                <td>
                  <Link to={`/shop/edit-product/${product.id}`} state={product}>
                    <FontAwesomeIcon icon={faPen} className="edit-icon" />
                  </Link>
                  <FontAwesomeIcon icon={faTrash} className="delete-icon" />
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default ManageProducts;
