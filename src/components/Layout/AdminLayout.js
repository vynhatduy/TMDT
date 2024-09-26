import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars, faSearch, faBell, faUserCircle } from '@fortawesome/free-solid-svg-icons';
import { Link, Outlet, useLocation } from 'react-router-dom';
import './AdminLayout.css';

const AdminLayout = () => {
  const [isSidebarCollapsed, setSidebarCollapsed] = useState(false);
  const [isSearchExpanded, setSearchExpanded] = useState(false); // State cho ô tìm kiếm
  const [isNotificationOpen, setNotificationOpen] = useState(false); // State cho thông báo
  const [isUserMenuOpen, setUserMenuOpen] = useState(false); // State cho menu người dùng
  const location = useLocation();

  const toggleSidebar = () => {
    setSidebarCollapsed(!isSidebarCollapsed);
  };

  const toggleSearch = () => {
    setSearchExpanded(!isSearchExpanded);
  };

  const toggleNotifications = () => {
    setNotificationOpen(!isNotificationOpen);
    setUserMenuOpen(false); // Đóng menu người dùng khi mở thông báo
  };

  const toggleUserMenu = () => {
    setUserMenuOpen(!isUserMenuOpen);
    setNotificationOpen(false); // Đóng thông báo khi mở menu người dùng
  };

  return (
    <div className={`admin-layout ${isSidebarCollapsed ? 'collapsed' : ''}`}>
      {/* Sidebar */}
      <nav className="admin-sidebar">
        <ul>
          <li>
            <Link to="/dashboard" className={location.pathname === '/dashboard' ? 'active' : ''}>
              <FontAwesomeIcon icon={faBars} />
              {!isSidebarCollapsed && <span>Dashboard</span>}
            </Link>
          </li>
          <li>
            <Link to="/shop-management" className={location.pathname === '/shop-management' ? 'active' : ''}>
              <FontAwesomeIcon icon={faBars} />
              {!isSidebarCollapsed && <span>Quản lý Shop</span>}
            </Link>
          </li>
          <li>
            <Link to="/product-statistics" className={location.pathname === '/product-statistics' ? 'active' : ''}>
              <FontAwesomeIcon icon={faBars} />
              {!isSidebarCollapsed && <span>Thống kê Sản phẩm</span>}
            </Link>
          </li>
          <li>
            <Link to="/voucher-management" className={location.pathname === '/voucher-management' ? 'active' : ''}>
              <FontAwesomeIcon icon={faBars} />
              {!isSidebarCollapsed && <span>Quản lý Voucher</span>}
            </Link>
          </li>
          <li>
            <Link to="/utilities" className={location.pathname === '/utilities' ? 'active' : ''}>
              <FontAwesomeIcon icon={faBars} />
              {!isSidebarCollapsed && <span>Tiện ích</span>}
            </Link>
          </li>
        </ul>
      </nav>

      {/* Main Content */}
      <div className="admin-content">
        {/* Navbar */}
        <div className="admin-navbar">
          <div className="navbar-left">
            <button onClick={toggleSidebar} className="menu-toggle-btn">
              <FontAwesomeIcon icon={faBars} />
            </button>
            {/* Thanh tìm kiếm */}
            <div className={`search-box ${isSearchExpanded ? 'expanded' : ''}`}>
              <input type="text" placeholder="Search..." />
              <button className="search-btn" onClick={toggleSearch}>
                <FontAwesomeIcon icon={faSearch} />
              </button>
            </div>
          </div>

          <div className="navbar-right">
            <div className="notification-icon" onClick={toggleNotifications}>
              <FontAwesomeIcon icon={faBell} />
            </div>
            {isNotificationOpen && (
              <div className="notification-dropdown">
                <ul>
                  <li>Thông báo 1</li>
                  <li>Thông báo 2</li>
                  <li>Thông báo 3</li>
                </ul>
              </div>
            )}
            <div className="user-icon" onClick={toggleUserMenu}>
              <FontAwesomeIcon icon={faUserCircle} />
            </div>
            {isUserMenuOpen && (
              <div className="user-dropdown">
                <ul>
                  <li>Thông tin người dùng</li>
                  <li>Đăng xuất</li>
                </ul>
              </div>
            )}
          </div>
        </div>

        <div className="content">
          <Outlet /> {/* Hiển thị nội dung của trang hiện tại */}
        </div>
      </div>
    </div>
  );
};

export default AdminLayout;
