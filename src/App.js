import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import AdminLayout from './components/Layout/AdminLayout';
import ShopLayout from './components/Layout/ShopLayout';

import Dashboard from './components/Admin/Dashboard';
import ManageShop from './components/Admin/ManageShop';
import ProductStatistics from './components/Admin/ProductStatistics';
import Orders from './components/Admin/Orders';
import ManageVouchers from './components/Admin/ManageVouchers';
import Utilities from './components/Admin/Utilities';

import ManageProducts from './components/Shop/ManageProducts';
import DashboardShop from './components/Shop/Dashboard';
import EditProduct from './components/Shop/EditProduct';
import AddProduct from './components/Shop/AddProduct';
import OrdersShop from './components/Shop/Orders';
import OrderDetailShop from './components/Shop/OrderDetail'; 

function App() {
  return (
    <Router>
      <Routes>
        {/* Routes for Admin */}
        <Route path="/" element={<AdminLayout />}>
          <Route index element={<Dashboard />} />
          <Route path="dashboard" element={<Dashboard />} />
          <Route path="shop-management" element={<ManageShop />} />
          <Route path="product-statistics" element={<ProductStatistics />} />
          <Route path="voucher-management" element={<ManageVouchers />} />
          <Route path="utilities" element={<Utilities />} />
        </Route>

        {/* Routes for Shop */}
        <Route path="/shop" element={<ShopLayout />}>
          <Route path="dashboard" element={<DashboardShop />} />
          <Route path="manage-products" element={<ManageProducts />} />
          <Route path="edit-product/:id" element={<EditProduct />} />
          <Route path="add-product" element={<AddProduct />} />
          <Route path="orders" element={<OrdersShop />} />
          <Route path="order-detail/:id" element={<OrderDetailShop />} />
        </Route>
      </Routes>
    </Router>
  );
}

export default App;
