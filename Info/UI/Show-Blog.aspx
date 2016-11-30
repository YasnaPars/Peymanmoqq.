<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Show-Blog.aspx.cs" Inherits="Show_Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <header class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-xs-5 col-sm-6">
                    <h1>Show Blog</h1>
                </div>
                <div class="col-xs-7 col-sm-6">
                    <div class="breadcrumbs">
                        <a href="/" title="">Home</a>
                        <i>/</i>
                        <a href="Blog.aspx" title="">Blog</a>
                        <i>/</i>
                        <span>Show Blog</span>
                    </div>
                </div>
            </div>
        </div>
    </header>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="col-md-8">
        <article class="post-blog post-blog2">
            <a class="pic-blog" href="Show-Blog.aspx" title="">
                <img class="img-responsive" src="Images/blog-pic1.jpg" title="" alt="" />
            </a>
            <div class="box-blog">
                <h3>
                    <a title="" href="Show-Blog.aspx">The news title goes here. The news title goes here. The news title goes here. The news title goes here.</a>
                </h3>
                <ul class="info-blog">
                    <li>
                        <a title="" href="#">
                            <i class="fa fa-calendar"></i>
                            12 Oct. 2016
                        </a>
                    </li>
                    <li>
                        <a title="" href="Show-Blog.aspx">
                            <i class="fa fa-comment"></i>
                            12 Comments
                        </a>
                    </li>
                </ul>
                <p>Lorizzle ipsizzle dolizzle sit amet, consectetuer adipiscing its fo rizzle. Nullam velizzle, fo shizzle my nizzle volutpizzle, suscipizzle quis, the bizzle vel, own yo'. Pellentesque go to hizzle away. Sed ma nizzle. Fizzle izzle dolizzle dapibizzle turpis tempizzle tempor. Maurizzle pellentesque own yo' mammasay mammasa mamma oo sa turpis. Vestibulum izzle tortor. Pellentesque that's the shizzle rhoncus dope. In i'm in the shizzle sheezy platea dictumst. Check it out dapibus. Curabitur tellivizzle we gonna chung, break yo neck, yall that's the shizzle, mattis ac, eleifend check out this, nunc. Phat fo shizzle. Integizzle for sure crackalackin ma nizzle own yo'.</p>
                <p>Vivamus nec hizzle pizzle nisi we gonna chung pretizzle. Funky fresh sit amizzle lacizzle. Black eu boom shackalack eget lacus pimpin' fo shizzle mah nizzle fo rizzle, mah home g-dizzle. Praesent suscipizzle stuff that's the shizzle. Curabitizzle fo shizzle arcu. Vestibulum enim mah nizzle, brizzle nizzle, congue tellivizzle, dignissim uhuh ... yih!, libero. Nullam vitae for sure non erizzle posuere break it down. Quisque pede tortizzle, rizzle pulvinar, auctizzle a, mollis stuff shizzlin dizzle, erizzle. Nizzle izzle tellivizzle. Aliquizzle risus gangsta, pizzle gizzle, sollicitudin in, consequat izzle, turpis. Quisque a brizzle boom shackalack mi rutrum vehicula. Curabitur accumsan sagittizzle ipsum. Daahng dawg habitant morbi phat senectus izzle dizzle ass yippiyo i saw beyonces tizzles and my pizzle went crizzle izzle turpizzle egestas. In shizznit. Curabitizzle elementum. Crackalackin pizzle da bomb, semper nizzle, suscipizzle daahng dawg, porta pulvinizzle, daahng dawg. Nulla sagittis gravida velit.</p>
                <p>Praesent tellivizzle daahng dawg izzle leo fo shizzle molestie. Ass get down get down tortor vizzle boom shackalack. Quisque malesuada ornare magna. Morbi crazy, nisl rizzle bibendizzle egestizzle, magna mah nizzle vestibulizzle dawg, izzle shit justo check out this quizzle augue. Rizzle id own yo' ma nizzle amizzle dang bow wow wow sagittizzle. Vivamizzle dope pede ut rizzle. I saw beyonces tizzles and my pizzle went crizzle rhoncizzle nonummy leo. Lorizzle ipsizzle dolizzle brizzle amet, consectetizzle bling bling elit. Phasellus nisi crackalackin, shut the shizzle up funky fresh funky fresh, facilisis sizzle, cool brizzle, libero. Mammasay mammasa mamma oo sa izzle faucibus diam. Ut i saw beyonces tizzles and my pizzle went crizzle tellivizzle. Nunc sizzle bizzle a dizzle accumsizzle shizzlin dizzle. Quisque condimentum metizzle shizzlin dizzle nunc. Aenean sodalizzle, fo quizzle brizzle lacinia, bow wow wow dizzle sheezy felizzle, nizzle ullamcorpizzle erizzle you son of a bizzle fizzle own yo'. Vivamizzle leo sheezy, rizzle da bomb amizzle, dang yippiyo, pulvinar , my shizz.</p>
                <div class="rating-box">
                    <i class="fa fa-info-circle" title="Please click to rate"></i>
                    <span>Rating 5.00 out of 5 by 11 person</span>
                    <div class="offer-rate">
                        <i class="fa fa-star Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Bad" title=""></i>
                        <i class="fa fa-star Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Weak" title=""></i>
                        <i class="fa fa-star Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Normal" title=""></i>
                        <i class="fa fa-star-o Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Good" title=""></i>
                        <i class="fa fa-star-o Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Excellent" title=""></i>
                    </div>
                    <div class="alert alert-success fade in">
                        <a class="close" href="#" title="Close" aria-label="close" data-dismiss="alert">×</a>
                        Your vote was recorded.
                    </div>
                </div>
            </div>
        </article>
        <div class="clearfix"></div>
        <hr />
        <div class="clearfix"></div>
        <ul class="pager">
            <li>
                <a href="Blog.aspx" title="">
                    <i class="fa fa-angle-left"></i>
                    Back
                </a>
            </li>
        </ul>
        <div class="clearfix"></div>
        <hr />
        <div class="clearfix"></div>
        <div class="comment-box">
            <h3>Comments (5)</h3>
            <div class="media">
                <a>
                    <img src="Images/avatar.png" title="" alt="" />
                </a>
                <div class="media-body">
                    <div>
                        <h4 class="media-heading">Joey Tribbiani</h4>
                        <div class="offer-rate">
                            <i class="fa fa-star"></i>
                            <i class="fa fa-star"></i>
                            <i class="fa fa-star-o"></i>
                            <i class="fa fa-star-o"></i>
                            <i class="fa fa-star-o"></i>
                        </div>
                    </div>
                    <span>February 29, 2012</span>
                    <div>Cras et quam lorem. Fusce rhoncus consequat nulla ut gravida. Sed adipiscing, lacus ac commodo scelerisque, est erat eleifend augue, nec viverra ligula lacus sed arcu</div>
                </div>
            </div>
            <div class="media">
                <a>
                    <img src="Images/avatar.png" title="" alt="" />
                </a>
                <div class="media-body">
                    <div>
                        <h4 class="media-heading">Monica Geller</h4>
                    </div>
                    <span>February 29, 2012</span>
                    <div>Cras et quam lorem. Fusce rhoncus consequat nulla ut gravida. Sed adipiscing, lacus ac commodo scelerisque, est erat eleifend augue, nec viverra ligula lacus sed arcu</div>
                </div>
            </div>
            <div class="media">
                <a>
                    <img src="Images/avatar.png" title="" alt="" />
                </a>
                <div class="media-body">
                    <div>
                        <h4 class="media-heading">Phoebe Buffay</h4>
                        <div class="offer-rate">
                            <i class="fa fa-star"></i>
                            <i class="fa fa-star-o"></i>
                            <i class="fa fa-star-o"></i>
                            <i class="fa fa-star-o"></i>
                            <i class="fa fa-star-o"></i>
                        </div>
                    </div>
                    <span>February 29, 2012</span>
                    <div>Cras et quam lorem. Fusce rhoncus consequat nulla ut gravida. Sed adipiscing, lacus ac commodo scelerisque, est erat eleifend augue, nec viverra ligula lacus sed arcu</div>
                </div>
            </div>
            <div class="media">
                <a>
                    <img src="Images/avatar.png" title="" alt="" />
                </a>
                <div class="media-body">
                    <div>
                        <h4 class="media-heading">Chandler Bing</h4>
                        <div class="offer-rate">
                            <i class="fa fa-star"></i>
                            <i class="fa fa-star"></i>
                            <i class="fa fa-star"></i>
                            <i class="fa fa-star"></i>
                            <i class="fa fa-star"></i>
                        </div>
                    </div>
                    <span>February 29, 2012</span>
                    <div>Cras et quam lorem. Fusce rhoncus consequat nulla ut gravida. Sed adipiscing, lacus ac commodo scelerisque, est erat eleifend augue, nec viverra ligula lacus sed arcu</div>
                </div>
            </div>
            <div class="media">
                <a>
                    <img src="Images/avatar.png" title="" alt="" />
                </a>
                <div class="media-body">
                    <div>
                        <h4 class="media-heading">Ross Geller</h4>
                    </div>
                    <span>February 29, 2012</span>
                    <div>Cras et quam lorem. Fusce rhoncus consequat nulla ut gravida. Sed adipiscing, lacus ac commodo scelerisque, est erat eleifend augue, nec viverra ligula lacus sed arcu</div>
                </div>
            </div>
            <hr />
            <h3>Post A Comment</h3>
            <form class="form-contact" role="form">
                <%-- <div class="alert alert-success fade in">
                    <a class="close" href="#" title="Close" aria-label="close" data-dismiss="alert">×</a>
                    <strong>Warning!</strong> Best check yo self, you're not looking too good.
                </div>
                <div class="alert alert-info fade in">
                    <a class="close" href="#" title="Close" aria-label="close" data-dismiss="alert">×</a>
                    <strong>Warning!</strong> Best check yo self, you're not looking too good.
                </div>
                <div class="alert alert-warning fade in">
                    <a class="close" href="#" title="Close" aria-label="close" data-dismiss="alert">×</a>
                    <strong>Warning!</strong> Best check yo self, you're not looking too good.
                </div>
                <div class="alert alert-danger fade in">
                    <a class="close" href="#" title="Close" aria-label="close" data-dismiss="alert">×</a>
                    <strong>Warning!</strong> Best check yo self, you're not looking too good.
                </div>--%>
                <div class="form-group">
                    <label>Name:</label>
                    <input type="text" class="form-control" placeholder="Enter Name" />
                </div>
                <div class="form-group">
                    <label>Email:</label>
                    <input type="text" class="form-control" placeholder="Enter Email" />
                </div>
                <div class="form-group">
                    <label>Comment:</label>
                    <textarea class="form-control" rows="4" placeholder="Enter Your Message …"></textarea>
                </div>
                <div class="form-group rating-box">
                    <i class="fa fa-info-circle" title="Please click to rate"></i>
                    <span>Rating 5.00 out of 5 by 11 person</span>
                    <div class="offer-rate">
                        <i class="fa fa-star Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Bad" title=""></i>
                        <i class="fa fa-star Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Weak" title=""></i>
                        <i class="fa fa-star Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Normal" title=""></i>
                        <i class="fa fa-star-o Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Good" title=""></i>
                        <i class="fa fa-star-o Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Excellent" title=""></i>
                    </div>
                </div>
                <div class="form-group">
                    <button type="submit" class="btn btn-submit btn-lg">Submit</button>
                </div>
            </form>
        </div>
    </div>
    <div class="col-xs-12 visible-sm">
        <hr />
    </div>
    <aside class="col-md-4">
        <div class="last-news mb25">
            <h3 class="title-design mb25">Other News</h3>
            <ul>
                <li>
                    <a href="Show-Blog.aspx" title="">
                        <img src="Images/news02.jpg" title="" alt="" />
                    </a>
                    <h4>
                        <a href="Show-Blog.aspx" title="">The news title goes here. The news title goes here. The news title goes here. The news title goes here.</a>
                    </h4>
                    <div class="clear"></div>
                </li>
                <li>
                    <a href="Show-Blog.aspx" title="">
                        <img src="Images/news03.jpg" title="" alt="" />
                    </a>
                    <h4>
                        <a href="Show-Blog.aspx" title="">The news title goes here. The news title goes here.</a>
                    </h4>
                    <div class="clear"></div>
                </li>
                <li>
                    <a href="Show-Blog.aspx" title="">
                        <img src="Images/news04.jpg" title="" alt="" />
                    </a>
                    <h4>
                        <a href="Show-Blog.aspx" title="">The news title goes here. The news title goes here.</a>
                    </h4>
                    <div class="clear"></div>
                </li>
                <li>
                    <a href="Show-Blog.aspx" title="">
                        <img src="Images/news01.jpg" title="" alt="" />
                    </a>
                    <h4>
                        <a href="Show-Blog.aspx" title="">The news title goes here. The news title goes here.</a>
                    </h4>
                    <div class="clear"></div>
                </li>
                <li>
                    <a href="Show-Blog.aspx" title="">
                        <img src="Images/news02.jpg" title="" alt="" />
                    </a>
                    <h4>
                        <a href="Show-Blog.aspx" title="">The news title goes here. The news title goes here.</a>
                    </h4>
                    <div class="clear"></div>
                </li>
                <li>
                    <a href="Show-Blog.aspx" title="">
                        <img src="Images/news03.jpg" title="" alt="" />
                    </a>
                    <h4 class="title-last-news">
                        <a href="Show-Blog.aspx" title="">The news title goes here. The news title goes here.</a>
                    </h4>
                    <div class="clear"></div>
                </li>
            </ul>
        </div>
        <div class="tag-box mb25">
            <h3 class="title-design mb25">Tags</h3>
            <a href="Show-Blog.aspx" title="">peyman moquette</a>
            <a href="Show-Blog.aspx" title="">news</a>
            <a href="Show-Blog.aspx" title="">business</a>
            <a href="Show-Blog.aspx" title="">economy</a>
            <a href="Show-Blog.aspx" title="">lolcats</a>
            <a href="Show-Blog.aspx" title="">design</a>
            <a href="Show-Blog.aspx" title="">moquette</a>
            <a href="Show-Blog.aspx" title="">Web</a>
            <a href="Show-Blog.aspx" title="">Photos</a>
        </div>
    </aside>
</asp:Content>
