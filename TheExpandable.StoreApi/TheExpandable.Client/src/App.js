import React, { Component } from "react";
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import { Table } from 'reactstrap';
import NavBar from './Navbar';
import axios from 'axios';

class App extends Component {
  state = {
    storeItems: []
  }

  componentWillMount(){
    axios.get('https://localhost:5001/Home/GetAll').then((response) =>{
      this.setState({
        storeItems: response.data
      })
    });
  }
  render(){
    return (
      <Router>
        <NavBar />  
        <Header />
        <div>
          <Route exact path="/" component={Home} />
          <Route path="/about" component={About} />
          <Route path="/topics" component={Topics} />
          <Route path="/items" component={Items} />
        </div>
      </Router>
    );
  }
}

function Home() {
  return <h2>Home</h2>;
}

function About() {
  return <h2>About</h2>;
}

function Topic({ match }) {
  return <h3>Requested Param: {match.params.id}</h3>;
}

function Topics({ match }) {
  return (
    <div>
      <h2>Topics</h2>

      <ul>
        <li>
          <Link to={`${match.url}/components`}>Components</Link>
        </li>
        <li>
          <Link to={`${match.url}/props-v-state`}>Props v. State</Link>
        </li>
      </ul>

      <Route path={`${match.path}/:id`} component={Topic} />
      <Route
        exact
        path={match.path}
        render={() => <h3>Please select a topic.</h3>}
      />
    </div>
  );
}

function Item({ match }) {
  return <h3>Requested Param: {match.params.id}</h3>;
}

function Items({ match }) {
  return (
    <div>
      <h2>Topics</h2>

      <ul>
        <li>
          <Link to={`${match.url}/allitems`}>All Items</Link>
        </li>
        <li>
          <Link to={`${match.url}/props-v-state`}>Props v. State</Link>
        </li>
      </ul>

      <Route path={`${match.path}/:id`} component={Item} />
      <Route
        exact
        path={match.path}
        render={() => <h3>Please select a topic.</h3>}
      />
    </div>
  );
}

function Header() {
  return (
    <Table>
      <thead>
        <th>
          <Link to="/">Home</Link>
        </th>
        <th>
          <Link to="/about">About</Link>
        </th>
        <th>
          <Link to="/topics">Topics</Link>
        </th>
        <th>
          <Link to="/items">Items</Link>
        </th>
      </thead>
    </Table>
  );
}

export default App;