import Layout,{Content, Header,Footer} from "antd/es/layout/layout";
import "./globals.css";
import {Menu} from "antd";
import Link from "next/link";

const items = [
    {key: "home", label: <Link href={"/"}>Home</Link>},
    {key: "books", label: <Link href={"/books"}>Books</Link>},
];

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
        <body>
          <Layout style={{minHeight: "100vh"}}>
              <Header>
                  <Menu 
                    theme="dark" 
                    mode="horizontal" 
                    items={items}
                    style={{flex:1, minWidth:0}}
                  />
              </Header>
              <Content style={{padding: "0 48px"}}>{children} </Content>
              <Footer style={{textAling: "center"}}>
                Book Store 2024 Created By Yaroslav Blossom
              </Footer>
          </Layout>
        
        </body>
    </html>
  );
}