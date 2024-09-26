import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrash, faTimes, faSave, faUpload } from '@fortawesome/free-solid-svg-icons';
import './AddProduct.css'; // Import CSS nếu cần

const AddProduct = () => {
  const [productName, setProductName] = useState('');
  const [productDetails, setProductDetails] = useState('');
  const [quantity, setQuantity] = useState('');
  const [price, setPrice] = useState('');
  const [category, setCategory] = useState('Điện thoại');
  const [brand, setBrand] = useState('');
  const [images, setImages] = useState([]);

  const handleImageUpload = (e) => {
    const files = Array.from(e.target.files);
    setImages([...images, ...files]);
  };

  const handleSave = () => {
    // Logic lưu sản phẩm mới vào cơ sở dữ liệu hoặc state ở đây
    alert('Sản phẩm mới đã được thêm!');
  };

  const handleDelete = () => {
    alert('Sản phẩm đã được xóa!');
  };

  return (
    <div className="add-product-layout">
      <div className="add-product-left">
        <div className="product-detail">
          <h2>Thêm sản phẩm mới</h2>
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
          <button onClick={handleSave} className="save-btn">
            <FontAwesomeIcon icon={faSave} /> Lưu
          </button>
          <button className="cancel-btn">
            <FontAwesomeIcon icon={faTimes} /> Hủy
          </button>
        </div>
      </div>

      <div className="add-product-right">
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

export default AddProduct;
