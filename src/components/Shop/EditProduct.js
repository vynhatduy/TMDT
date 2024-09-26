import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrash, faTimes, faSave, faUpload } from '@fortawesome/free-solid-svg-icons';
import { useLocation, useNavigate } from 'react-router-dom';
import './EditProduct.css';

const EditProduct = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const product = location.state; // Get the product data from state

  const [productName, setProductName] = useState(product.name);
  const [productDetails, setProductDetails] = useState(product.details);
  const [quantity, setQuantity] = useState(product.quantity);
  const [price, setPrice] = useState(product.price);
  const [category, setCategory] = useState(product.category);
  const [brand, setBrand] = useState(product.brand);
  const [images, setImages] = useState([]);

  const handleImageUpload = (e) => {
    const files = Array.from(e.target.files);
    setImages([...images, ...files]);
  };

  const handleSave = () => {
    alert('Sản phẩm đã được lưu!');
    // Bạn có thể thêm logic lưu sản phẩm tại đây
    navigate('/shop/manage-products'); // Quay về trang quản lý sản phẩm sau khi lưu
  };

  const handleDelete = () => {
    alert('Sản phẩm đã được xóa!');
    // Bạn có thể thêm logic xóa sản phẩm tại đây
  };

  const handleCancel = () => {
    navigate('/shop/manage-products'); // Quay về trang quản lý sản phẩm khi hủy
  };

  return (
    <div className="edit-product-layout">
      <div className="edit-product-left">
        <div className="product-detail">
          <h2>Chi tiết sản phẩm</h2>
          <input
            type="text"
            value={productName}
            onChange={(e) => setProductName(e.target.value)}
            placeholder="Tên sản phẩm"
          />
        </div>

        <hr />

        <div className="basic-info">
          <h3>Thông tin cơ bản</h3>
          <label>Tên sản phẩm:</label>
          <input
            type="text"
            value={productName}
            onChange={(e) => setProductName(e.target.value)}
          />
          <label>Chi tiết sản phẩm:</label>
          <textarea
            value={productDetails}
            onChange={(e) => setProductDetails(e.target.value)}
          ></textarea>
        </div>

        <hr />

        <div className="pricing">
          <h3>Định giá sản phẩm</h3>
          <label>Số lượng sản phẩm:</label>
          <input
            type="number"
            value={quantity}
            onChange={(e) => setQuantity(e.target.value)}
          />
          <label>Giá trị trên 1 sản phẩm:</label>
          <input
            type="number"
            value={price}
            onChange={(e) => setPrice(e.target.value)}
          />
        </div>

        <hr />

        <div className="category-selection">
          <h3>Danh mục sản phẩm</h3>
          <label>Chọn danh mục:</label>
          <select value={category} onChange={(e) => setCategory(e.target.value)}>
            <option value="Điện thoại">Điện thoại</option>
            <option value="Máy tính">Máy tính</option>
            <option value="Phụ kiện">Phụ kiện</option>
          </select>
          <label>Thương hiệu:</label>
          <input
            type="text"
            value={brand}
            onChange={(e) => setBrand(e.target.value)}
          />
        </div>

        <hr />

        <div className="action-buttons">
          <button onClick={handleDelete} className="delete-btn">
            <FontAwesomeIcon icon={faTrash} /> Xóa sản phẩm
          </button>
          <button onClick={handleSave} className="save-btn">
            <FontAwesomeIcon icon={faSave} /> Lưu
          </button>
          <button onClick={handleCancel} className="cancel-btn">
            <FontAwesomeIcon icon={faTimes} /> Hủy
          </button>
        </div>
      </div>

      <div className="edit-product-right">
        <div className="product-images">
          <h3>Hình ảnh sản phẩm</h3>
          <label>Chọn hình ảnh:</label>
          <input type="file" accept="image/*" multiple onChange={handleImageUpload} />
          <div className="image-list">
            {images.map((image, index) => (
              <div key={index} className="image-item">
                <img src={URL.createObjectURL(image)} alt={`Product Image ${index + 1}`} />
              </div>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
};

export default EditProduct;
