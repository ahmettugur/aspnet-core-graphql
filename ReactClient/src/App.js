import React, { Component } from "react";
import { Route } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.css";
import "./App.css";
import MainPage from "./components/mainpage";
import ProductList from "./components/product-list";
import NavBar from "./components/nav-bar";
import OrderList from "./components/order-list";

class App extends Component {
  render() {
    return (
      <div className="container">
      <NavBar />
          <Route path="/" exact component={MainPage} />
          <Route path="/products" exact component={ProductList} />
          <Route path="/orders" exact component={OrderList} />
      </div>
    );
  }
}

export default App;
