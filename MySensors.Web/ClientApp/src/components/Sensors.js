import React, {Component} from 'react';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import {Card, CardActionArea, CardActions, CardContent, CardHeader, CardMedia, IconButton} from "@material-ui/core";
import MoreVertIcon from '@material-ui/icons/MoreVert';
import SensorsService from '../services/sensors.service'
import Container from "@material-ui/core/Container";
import Grid from "@material-ui/core/Grid";
import AddBoxIcon from '@material-ui/icons/AddBox';
import {green} from "@material-ui/core/colors";

const useStyles = theme => ({
  paper: {
    marginTop: theme.spacing(8),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  }
});

class Sensors extends Component {
  static displayName = Sensors.name;
  
  constructor(props) {
    super(props);
    
    this.state = { sensorsData: [], error: ""};
  }

  async componentDidMount() {
    await this.getSensorsData();
  }
  
  render () {
    const { classes } = this.props;
    var sensors = this.state.sensorsData;

    return (
        <Grid alignItems="stretch" container spacing={2}>
        {sensors && sensors.map((sensor, index) =>
          <Grid style={{display: "flex", flexDirection: "column"}} item xs={12} sm={4} lg={3}>
            <Card style={{height: "100%"}}>
              <CardHeader
                  action={
                    <IconButton href={"/sensors/properties/" + sensor.id} aria-label="settings">
                      <MoreVertIcon />
                    </IconButton>
                  }
                  title={sensor.sensorName}
                  subheader={sensor.lastUpdate ? "Updated at " + sensor.lastUpdate: "No data"}
              />
                <CardMedia
                    image="/static/images/cards/sensor.jpg"
                />
                <CardContent>
                  {sensor.sensorParameters.map((parameter, index) =>
                  <Typography variant="body2" color="textSecondary" component="p">
                    <Typography display="inline" style={{fontWeight: "bold"}}>{parameter.humanReadableName}: </Typography>
                    <Typography display="inline">{parameter.value ? parameter.value:"No data"}</Typography>
                  </Typography>
                  )}
                </CardContent>
              <CardActions>
                <Button href={"/sensors/details/" + sensor.id} size="small" color="primary">
                  Learn More
                </Button>
              </CardActions>
            </Card>
          </Grid>
        )}
          <Grid style={{display: "flex", flexDirection: "column"}} item xs={12} sm={4} lg={3}>
            <Button href="/sensors/add" style={{height: "100%"}} startIcon={<AddBoxIcon style={{fontSize: 50, color: green[500]}}/>}/>
          </Grid>
        </Grid>
    );
  }

  async getSensorsData() {
    try {
      this.setState( {
        sensorsData: await SensorsService.getSensors()
      });
    }
    catch(e)
    {
      this.setState({
        error: e
      });
    }
    
  }
}

Sensors.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(useStyles)(Sensors);