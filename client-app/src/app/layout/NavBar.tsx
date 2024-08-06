import { Button, Container, Dropdown, Menu, Image } from "semantic-ui-react";

export default function NavBar() {



    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item to='/' header>
                    <img src="src/assets/logo.png" alt="logo" style={{marginRight: '10px'}} />
                    Reactivities
                </Menu.Item>
                <Menu.Item  to='/activities' name='Activities' />
                <Menu.Item  to='/errors' name='Errors' />
                <Menu.Item>
                    <Button  to='/createActivity' positive content='Create Activity' />
                </Menu.Item>
                <Menu.Item position='right'>
                    <Image  avatar spaced='right' />
                    <Dropdown pointing='top left'>
                        <Dropdown.Menu>
                            <Dropdown.Item  text='My Profile' icon='user' />
                            <Dropdown.Item  text='Logout' icon ='power' />
                        </Dropdown.Menu>
                    </Dropdown>
                </Menu.Item>
            </Container>
        </Menu>
    )
}
