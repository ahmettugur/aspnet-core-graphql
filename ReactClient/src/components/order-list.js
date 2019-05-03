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
    axios.post("http://localhost:3909/graphql", {
      query
    }).then(response => {
      this.setState({
        orders: response.data.data.allOrders
      });
    });
    // We call the method here to execute our async function
    //this.getOrders(query);
  }

  getOrders = async query => {
    try {
      await axios.post("http://localhost:3909/graphql", {
        query
      }).then(response => {
        this.setState({
          orders: response.data.data.allOrders
        });
      });
    } catch (error) {
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
