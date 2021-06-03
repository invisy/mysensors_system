import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import SignIn from './components/SignIn';
import SignUp from './components/SignUp';
import Sensors from "./components/Sensors";
import {ShowSensorDetails} from "./components/ShowSensorDetails";

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/sign-in' component={SignIn} />
        <Route exact path='/sign-up' component={SignUp} />
        <Route exact path='/sensors/' component={Sensors} />
        <Route exact path='/sensors/details/:id/' component={ShowSensorDetails} />
      </Layout>
    );
  }
}
