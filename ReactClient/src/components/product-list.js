import React from "react";
import axios from "axios";
import { Table } from "reactstrap";
import Paging from "./paging";

export default class ProductList extends React.Component {
  state = {
    products: [],
    currentCategory: 0,
    currentPage: 0,
    pageCount: 0,
    pageSize: 0
  };

  fetcproduct() {
    const categoryId = 0;
    const page =
      this.props.match.params.page === undefined
        ? 1
        : this.props.match.params.page;

    // This is the GraphQL query
    const query = `
  query {
    allProduct(categoryId:${categoryId},page:${page}){
      currentCategory
      currentPage
      pageCount
      pageSize
      products{
        productID
        productName
        unitPrice
      }
    }
  }
`;
    // We call the method here to execute our async function
    this.getProducts(query);
  }

  componentWillMount() {
    this.fetcproduct();
  }

  getProducts = async query => {
    try {
      const response = await axios.post("http://localhost:3909/graphql", {
        query
      }).then( response => {
        console.log("response.data.data.allProduct");
        this.setState({
          products: response.data.data.allProduct.products,
          currentCategory: response.data.data.allProduct.currentCategory,
          currentPage: response.data.data.allProduct.currentPage,
          pageCount: response.data.data.allProduct.pageCount,
          pageSize: response.data.data.allProduct.pageSize
        });
        //console.log(response.data.data.allProduct);
        //console.log(response)
    });
      // console.log(response.data.data.allProduct);

      // this.setState({
      //   products: response.data.data.allProduct.products,
      //   currentCategory: response.data.data.allProduct.currentCategory,
      //   currentPage: response.data.data.allProduct.currentPage,
      //   pageCount: response.data.data.allProduct.pageCount,
      //   pageSize: response.data.data.allProduct.pageSize
      // });
    } catch (error) {
      // If there's an error, set the error to the state
      console.log(error);
    }
  };
  componentWillReceiveProps(nextProps) {
    console.log(nextProps);
    this.fetcproduct();
  }
  renderProducts() {

    if (this.state.products.length === 0) {
      return (
        <tr>
          <td colSpan={3}> Loading... </td>
        </tr>
      );
    }
    return this.state.products.map(product => {
      return (
        <tr key={product.productID} id={"product_" + product.productID}>
          <td>{product.productID}</td>
          <td>{product.productName}</td>
          <td> {product.unitPrice} </td>
        </tr>
      );
    });
  }

  render() {
    return (
      <div>
        <div>
          <Table>
            <thead>
              <tr>
                <th>Product Id</th>
                <th>Product Name</th>
                <th>Unit Price</th>
              </tr>
            </thead>
            <tbody>{this.renderProducts()}</tbody>
          </Table>
        </div>
        <div>
          <Paging
            url="/products"
            type="products"
            pageSize={this.state.pageSize}
            pageCount={this.state.pageCount}
            currentCategory={this.state.categoryId}
          />
        </div>
      </div>
    );
  }
}
