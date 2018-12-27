import React from "react";
import axios from "axios";
import { Table } from "reactstrap";

export default class ProductList extends React.Component {
  state = {
    products: []
  };

  componentDidMount() {
    // This is the GraphQL query
    const query = `
    query {
      allProduct{
        productID
        productName
        unitPrice
      }
    }
    `;
    // We call the method here to execute our async function
    this.getProducts(query);
  }

  getProducts = async query => {
    try {
      const response = await axios.post("http://localhost:3909/graphql", {
        query
      });

      this.setState({
        products: response.data.data.allProduct
      });
    } catch (error) {
      // If there's an error, set the error to the state
      console.log(error);
    }
  };

  renderProducts() {
    if (this.state.products.length === 0) {
      return (
        <tr>
          <td colSpan={3}> Loading... </td>
        </tr>
      );
    }
    return this.state.products.map((product) => {
      return (
        <tr key={product.productID} id={"product_"+product.productID}>
          <td>{product.productID}</td>
          <td>{product.productName}</td>
          <td> {product.unitPrice} </td>
        </tr>
      );
    });
  }

  render() {
    return (
      <Table>
        <thead>
          <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Username</th>
          </tr>
        </thead>
        <tbody>{this.renderProducts()}</tbody>
      </Table>
    );
  }
}
