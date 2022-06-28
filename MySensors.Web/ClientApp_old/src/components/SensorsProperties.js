import React, {Component} from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import {Card, CardActionArea, CardActions, CardContent, CardHeader, CardMedia, IconButton} from "@material-ui/core";
import SensorsService from '../services/sensors.service'

import Grid from "@material-ui/core/Grid";
import Alert from "@material-ui/lab/Alert";
import Container from "@material-ui/core/Container";
import Box from "@material-ui/core/Box";
import {Link} from "react-router-dom";
import Button from "@material-ui/core/Button";


const useStyles = theme => ({
});

class SensorsProperties extends Component {
  static displayName = SensorsProperties.name;
  
  constructor(props) {
    super(props);
    
    this.state = { token: "", parameters: [], error: ""};
  }

  async componentDidMount() {
    await this.loadToken(this.props.match.params.id);
    await this.loadParameters(this.props.match.params.id);
  }

  render () {
    const { classes } = this.props;

    return (
        <Container component="main" maxWidth="xl">
          {this.state.error && <Alert xl={12} variant="outlined" severity="error">{this.state.error}</Alert>}
          <Grid maxWidth="xl" alignItems="stretch" container spacing={2}>
            <Grid item xs={12}>
              <Button onClick={() => this.deleteSensor(this.props.match.params.id)} variant="contained" color="secondary">Delete sensor</Button>
            </Grid>
            <Grid item>
              <Box fontWeight="fontWeightBold">He is url which you can use with your sensor to track data:</Box>
            </Grid>
            <Grid item>
              <Card body>
                {window.location.origin + "/api/sensorData/add?token=" + this.state.token +
                this.state.parameters.map((parameter) => "&"+parameter.requestName+"=22,5").join('')}
              </Card>
            </Grid>
          </Grid>
        </Container>
    );
  }

  async loadToken(id) {
    try {
      const resultToken = await SensorsService.getToken(id);
      if(resultToken.status === 200)
      {
        await this.setState( {
          token: resultToken.data.token,
          error: ""
        });
      }
    }
    catch
    {
      await this.setState({
        error: "Connection problems..."
      });
    }
  }

  async loadParameters(id) {
    try {
      const result = await SensorsService.getParametersBySensorId(id);
      if(result.status === 200)
      {
        await this.setState( {
          parameters: result.data,
          error: ""
        });
      }
    }
    catch
    {
      await this.setState({
        error: "Connection problems..."
      });
    }
  }

  async deleteSensor(id) {
    try {
      const result = await SensorsService.removeSensorById(id);
      if(result.status === 200)
      {
        this.props.history.push("/sensors");
      }
    }
    catch
    {
      await this.setState({
        error: "Connection problems..."
      });
    }
  }
}

SensorsProperties.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(useStyles)(SensorsProperties);