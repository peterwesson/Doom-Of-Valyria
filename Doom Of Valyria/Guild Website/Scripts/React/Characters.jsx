var CharacterList = React.createClass({
    displayName: 'CharacterList',
    getInitialState: function() {
        return {data: []};
    },
    componentWillMount: function() {
        var xhr = new XMLHttpRequest();
        xhr.open('get', "/Characters/GetCharacters", true);
        xhr.onload = function() {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    },
    render: function () {
        var characters = this.state.data.map((character) =>
            <Character data={character} key={character.Name} />
        );
        return (
            <div>
                <h2>Characters</h2>
                {characters}
            </div>
        );
    }
});

var Character = React.createClass({
    displayName: 'Character',
    getInitialState: function () {
        return { data: this.props.data };
    },
    render: function () {
        var equipmentItems = this.state.data.Equipment.map((equipmentItem) =>
            <Item data={equipmentItem.Item} skin={equipmentItem.Skin} key={this.state.data.Name + "-" + equipmentItem.Slot} />
        );
        return (
            <div>
                <h3>
                    {this.state.data.Name}
                </h3>
                {equipmentItems}
            </div>
        );
    }
});

var Item = React.createClass({
    displayName: 'Item',
    getInitialState: function () {
        return { data: this.props.data };
    },
    render: function () {
        var imageUrl = (this.props.skin != null) ? this.props.skin.IconUrl : this.state.data.IconUrl;

        return (
           <img src={imageUrl} />                
        );
    }
});

ReactDOM.render(
  <CharacterList />,
  document.getElementById('characters')
);