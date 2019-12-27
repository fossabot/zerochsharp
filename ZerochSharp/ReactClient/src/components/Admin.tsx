import React from 'react';
import {
  Typography,
  Box,
  makeStyles,
  Theme,
  AppBar,
  Tab
} from '@material-ui/core';
import { Switch, Route, RouteComponentProps } from 'react-router-dom';
import { Plugin } from '../components/Plugin';

interface AdminTabProps {
  children: React.ReactNode;
  index: any;
  value: any;
}

type Props = AdminTabProps;

const AdminTabs = (props: Props) => {
  const { children, value, index, ...other } = props;
  return (
    <Typography
      component="div"
      role="tabpanel"
      hidden={value !== index}
      id={`wrapped-admin-tabpanel-${index}`}
      aria-labbelledby={`wrapped-admin-tab-${index}`}
      {...other}
    >
      {value === index && <Box p={3}>{children}</Box>}
    </Typography>
  );
};

const a11yProps = (index: any) => {
  return { id: `wrapped-admin-tab-${index}` };
};

const useStyle = makeStyles((theme: Theme) => ({
  root: {
    flexGrow: 1,
    backgroundColor: theme.palette.background.paper
  }
}));

export const Admin = () => {
  const classes = useStyle();
  const [value, setValue] = React.useState('one');
  return (
    <>
      <h1>Hello, Admin Page</h1>
      {/* <p>Hello, admin page!</p>
      <div className={classes.root}>
        <AppBar position="static" aria-label="wrapped label tabs admin">
          <Tab value="one" label="Plugins"/>
        </AppBar>
      </div> */}
    </>
  );
};
