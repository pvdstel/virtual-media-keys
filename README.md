# virtual-media-keys

Some [AutoHotkey](https://autohotkey.com/) scripts meant for people with
keyboards without media keys. These scripts intercept some hotkeys and
send media keys in their place. You may download the scripts from the
`src` folder, or you can get the compiled binaries from the Releases page.

There are currently two flavors: arrow keys and navigation keys. The first
one binds to the arrow keys, while the second one binds to navigation
keys.

<table>
    <thead>
        <tr>
            <th rowspan="2">Command</th>
            <th colspan="2">Flavor</th>
        </tr>
        <tr>
            <th>Arrows</th>
            <th>Navigation</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <th>Play/pause</th>
            <td>
                <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>↑</kbd>
                <br/>
                <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>↓</kbd>
            </td>
            <td>
                <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>PgUp</kbd>
                <br/>
                <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>PgDn</kbd>
            </td>
        </tr>
        <tr>
            <th>Previous</th>
            <td><kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>←</kbd></td>
            <td><kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>Home</kbd></td>
        </tr>
        <tr>
            <th>Next</th>
            <td><kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>→</kbd></td>
            <td><kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>End</kbd></td>
        </tr>
        <tr>
            <th>Volume up</th>
            <td><kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>Shift</kbd> + <kbd>↑</kbd></td>
            <td><kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>Shift</kbd> + <kbd>PgUp</kbd></td>
        </tr>
        <tr>
            <th>Volume down</th>
            <td><kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>Shift</kbd> + <kbd>↓</kbd></td>
            <td><kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>Shift</kbd> + <kbd>PgDn</kbd></td>
        </tr>
        <tr>
            <th>Mute</th>
            <td>
                <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>Shift</kbd> + <kbd>←</kbd>
                <br/>
                <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>Shift</kbd> + <kbd>→</kbd>
            </td>
            <td>
                <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>Shift</kbd> + <kbd>Home</kbd>
                <br/>
                <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>Shift</kbd> + <kbd>End</kbd>
            </td>
        </tr>
    </tbody>
</table>

## Running / compiling

The scripts can be executed directly using
[AutoHotkey](https://autohotkey.com/). It also allows for compiling the
scripts. Binary files attached to releases have been modified to use the
complete icon set.
