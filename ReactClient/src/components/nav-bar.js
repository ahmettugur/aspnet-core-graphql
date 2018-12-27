import React from "react";
import logo from "../logo.svg";
import { Link } from "react-router-dom";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink
} from "reactstrap";

export default class NavBar extends React.Component {
  constructor(props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false
    };
  }
  toggle() {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }
  render() {
    return (
      <div>
        <Navbar color="light" light expand="md">
          <NavbarBrand href="/">
            <img src={logo} width="35px" height="35px" />
          </NavbarBrand>
          <NavbarToggler onClick={this.toggle} />
          <Collapse isOpen={this.state.isOpen} navbar>
            <Nav className="ml-auto custom-nav" navbar>
              <NavItem>
                  <Link className="nav-link" to="/products">Ürünler</Link>
              </NavItem>
              <NavItem>
                <Link className="nav-link" to="/orders">Siparisler</Link>
              </NavItem>
              <NavItem>
                <Link className="nav-link" to="/suppliers">Tedarikciler</Link>
              </NavItem>
              <NavItem>
                <Link className="nav-link" to="/customers">Müşteriler</Link>
              </NavItem>
            </Nav>
          </Collapse>
        </Navbar>
      </div>
    );
  }
}
