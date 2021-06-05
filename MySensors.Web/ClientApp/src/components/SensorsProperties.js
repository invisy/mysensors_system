import React, {Component} from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import {Card, CardActionArea, CardActions, CardContent, CardHeader, CardMedia, IconButton} from "@material-ui/core";
import SensorsService from '../services/sensors.service'

import Grid from "@material-ui/core/Grid";
import Alert from "@material-ui/lab/Alert";
import Container from "@material-ui/core/Container";


const useStyles = theme => ({
});

class SensorsProperties extends Component {
  static displayName = SensorsProperties.name;
  
  constructor(props) {
    super(props);
    
    this.state = { token: "", parameters :[], error: ""};
  }

  async componentDidMount() {
    await this.loadData();
  }

  render () {
    const { classes } = this.props;

    return (
        <Container component="main" maxWidth="xl">
          {this.state.error && <Alert xl={12} variant="outlined" severity="error">{this.state.error}</Alert>}
          <Card body>{window.location.origin + "/api/sensorData/add?token=" + this.state.token}</Card>
          <Grid maxWidth="xl" alignItems="stretch" container spacing={2}>
            
          </Grid>
        </Container>
    );
  }

  async loadData() {
    try {
      const resultToken = await SensorsService.getToken(1);
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
}

SensorsProperties.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(useStyles)(SensorsProperties);