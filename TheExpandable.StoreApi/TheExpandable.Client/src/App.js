import React, { Component} from 'react';
import MyComponent from './MyComponent';
import './App.css';

class App extends Component {
  constructor(props){
    super(props);

    this.state = {
      title: 'app title'
    }

    this.onClick = this.onClick.bind(this);
  }

  onClick() {
    this.setState({
      title: 'OOooo Clicked!'
    });
  }

  render() {
    const title = "Welcome to our Web Store :)";

    return (
      <div className="App">
        <header className="App-header">
          <h1>{this.state.title}</h1>
        </header>
        <body>
          <MyComponent 
          title="This is component title"
          name="This is component name"
          onClick={this.onClick}
          />
        </body>
      </div>
    );
  }

}

export default App;
