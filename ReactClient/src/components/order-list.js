import React, {Component} from "react";
import axios from "axios";
import { Table } from "reactstrap";

export default class OrderList extends Component {
  state = {
    orders: []
  };

  componentDidMount() {
    // This is the GraphQL query
    const query = `
    query {
        allOrders{
          orderID
          customerID
          employeeID
          orderDate
          customer{
            companyName
            contactName
          }
        }
      }      
    `;
    // We call the method here to execute our async function
    this.getOrders(query);
  }

  getOrders = async query => {
    try {
      const response = await axios.post("http://localhost:3909/graphql", {
        query
      });

      this.setState({
        orders: response.data.data.allOrders
      });
    } catch (error) {
      // If there's an error, set the error to the state
      console.log(error);
    }
  };

  renderOrders() {
    if (this.state.orders.length === 0) {
      return (
        <tr>
          <td colSpan={4}> Loading... </td>
        </tr>
      );
    }
    return this.state.orders.map((order) => {
      return (
        <tr key={order.orderID} id={"order_"+order.orderID}>
          <td>{order.orderID}</td>
          <td>{order.orderDate}</td>
          <td>{order.customer.companyName}</td>
          <td> {order.customer.contactName} </td>
        </tr>
      );
    });
  }

  render() {
    return (
      <Table>
        <thead>
          <tr>
            <th>Order Id</th>
            <th>Order Date</th>
            <th>Company Name</th>
            <th>Contact Name</th>
          </tr>
        </thead>
        <tbody>{this.renderOrders()}</tbody>
      </Table>
    );
  }
}
