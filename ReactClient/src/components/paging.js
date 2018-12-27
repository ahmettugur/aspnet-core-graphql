import React, { Component } from "react";
import Pagination from "react-js-pagination";
import PropTypes from "prop-types";
import "bootstrap/dist/css/bootstrap.css";

export default class Paging extends Component {
  constructor(props) {
    super(props);
    this.state = {
      activePage: 1,
      url: props.url,
      type: props.type
    };
    this.handlePageChange = this.handlePageChange.bind(this);
    this.redirectProductsPage = this.redirectProductsPage.bind(this);
  }

  handlePageChange(pageNumber) {
    console.log(`active page is ${pageNumber}`);
    this.setState({
      activePage: pageNumber
    });

    if (this.state.type === "products") {
      this.redirectProductsPage(pageNumber, this.state.url);
    }
  }
  redirectProductsPage(num, url) {
    let currentCategory = 0;
    if (this.context.router.route.match.params.categoryId !== undefined) {
      currentCategory = this.context.router.route.match.params.categoryId;
    }
    this.context.router.history.push(url + "/" + currentCategory + "/" + num);
  }

  render() {
    return (
      <div>
        <Pagination
          itemClass="page-item"
          linkClass="page-link"
          activePage={this.state.activePage}
          //   itemsCountPerPage={this.props.PageSize}
          totalItemsCount={this.props.pageCount}
          pageRangeDisplayed={this.props.pageSize}
          onChange={this.handlePageChange}
        />
      </div>
    );
  }
}
Paging.contextTypes = {
  router: PropTypes.object
};

// import Pager from 'react-pager';
// import PropTypes from 'prop-types';

// import $ from 'jquery';
// import 'bootstrap/dist/css/bootstrap.css';
// window.jQuery = $;
// require('bootstrap');

// export default class Paging extends Component {
//     constructor(props) {
//         super(props);

//         this.handlePageChanged = this.handlePageChanged.bind(this);
// console.log(props)
//         this.state = {
//             total: props.PageCount,
//             current: 0,
//             visiblePage: props.PageSize,
//             url: props.url,
//             type: props.type
//         };
//     }
//     componentWillMount() {
//         let currentPage = 0;
//         if (this.context.router.route.match.params.page != undefined) {
//             currentPage = this.context.router.route.match.params.page-1;

//         }
//         this.setState({ current: currentPage });
//     }
//     handlePageChanged(newPage) {

//         this.setState({ current: newPage });
//         if (this.state.type === "products") {
//             this.redirectProductsPage(newPage + 1, this.state.url);
//         }
//         else if (this.state.type === "adminProducts") {
//             this.redirectAdminProductsPage(newPage + 1, this.state.url);
//         }
//     }
//     redirectProductsPage(num, url) {
//         let currentCategory = 0;
//         if (this.context.router.route.match.params.categoryId !== undefined) {
//             currentCategory = this.context.router.route.match.params.categoryId;
//         }
//         this.context.router.history.push(url + "/" + currentCategory + "/" + num)

//     }
//     redirectAdminProductsPage(num, url) {
//         this.context.router.history.push(url + "/" + num)
//     }

//     render() {

//         return (
//             <Pager
//                 total={this.props.PageCount}
//                 current={this.state.current}
//                 visiblePages={this.props.PageSize}
//                 titles={{ first: 'First', last: 'Last' }}
//                 className="pagination-right"
//                 onPageChanged={this.handlePageChanged}
//             />
//         );
//     }
// }

// Paging.contextTypes = {
//     router: PropTypes.object
// }
