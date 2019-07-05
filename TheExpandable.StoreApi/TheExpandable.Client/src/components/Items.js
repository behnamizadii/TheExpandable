import React, { Component } from "react";
import axios from "axios";
import { Table } from "reactstrap";

class StoreItems extends Component {
  state = {
    storeItems: []
  };

  componentWillMount() {
    axios.get("https://localhost:5001/Home/GetAll").then(response => {
      this.setState({
        storeItems: response.data
      });
    });
  }

  render() {
    let storeitems = this.state.storeItems.map(item => {
      return (
        <tr>
          <td>{item.itemId}</td>
          <td>{item.name}</td>
          <td>{item.price}</td>
        </tr>
      );
    });
    return (
      <Table>
        <thead>
          <tr>
            <td>Item Id</td>
            <td>Item Name</td>
            <td>Item Price</td>
          </tr>
        </thead>
        <tbody>{storeitems}</tbody>
      </Table>
    );
  }
}

export default StoreItems;
